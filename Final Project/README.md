

## Why I Chose the Topic
This challenge is related to my research project in BUVIAR Lab. In the project, I wrote a script to take an RGB and depth image of the scene with a frequency I specify, which is an independent variant. But as I increase the frequency, I realize that the game periodically freezes for a really short but hard not to notice time interval. We always perceive games as fun tools, I am aware that this context is a little far away and a little niche among the ones I could have chosen, but this was a problem I experienced from first hand and I wanted to search and experiment on the possible solutions I would have tried if I wanted to eliminate it.
Experimental Design
I wanted to display a basic and simultaneously tractable settings that vary only on a single aspect that I believe would be sufficient to reflect the purpose of the experiment. I chose that significant independent variable to be the speed of the objects. The speeds are decided with trial and error: I wanted to set them with higher speeds but they faced tunneling at early stages of the experiment thus I limited them to speed 90.
The scene basically consists of:
1.	Four balls with speeds 30, 60, 90. They do a harmonic motion with constant speed, changing directions at each collision with the invisible walls.
2.	A wooden floor just for aesthetic purposes: the balls don’t interact with the floor as they are not affected by the gravity thus not touching the floor.
3.	A light source
4.	Invisible walls surrounding the experiment setting.
5.	Texts attached to balls demonstrating their supposed to be speed values. (they deviate as the game proceeds)

I have three Capture Orchestrator objects that act as dependent variables. I will investigate the game elements and parameters activating a single one among them at each run. They technically are objects without renders that has scripts attached to them to execute the screen capture with differing technics. A more detailed explanation is as follows:

**1.	Screen capture with coroutines:**
This uses Unity Coroutines which enable me to spread a computationally large function to multiple update frames. I divided the coroutine into three update loops, giving IO manipulation part solely to a single update along with giving pre-IO and post-IO parts to separate update turns. To provide that no multiple capturing events work in parallel but only work serially, I used a mutex-like structure through a Boolean “locked” which is checked at each update loop to decide on igniting the execution of the coroutine.

**2.	Screen capture with asynchronous methods:**
This uses asynchronously running Update loops. Asynchronous parts are written with Task typed functions and are called with await keywords inside encapsulating asynchronous functions. Another detail is that these asynchronous parts may run on a separate thread from the main game thread, but in our case since Update method runs on main thread, an asynchronous call inside it will also run on main thread. It still is advantageous because it is a non-blocking call to the function; main thread continues execution of other tasks too which also provides parallelism to some extent. In my code, I separated only the IO operation part into the asynchronous part (detailed reason is after this section). I again utilized mutex-like structure using a Boolean atomicLock variable to provide that a capture waits for the previous ones’ termination.

**3.	Screen capture with Unity jobs:**
Unity job system do not generate as much garbage as asynchronous approach do, and utilize Unity’s worker threads. When used with Burst compiler, I could have created a smoother game bot this still will demonstrate high optimization. I simultaneously used the mutex logic again too to provide that sequential captures are taken and the sequence of screenshots are in line with chronological order, through the Boolean done.
The technical challenge here was that I wanted to fixate the atomic code peace that did the experimental act I was testing. Doing so, I faced some restrictions due to threads: some methods opened up separate threads other than the main thread unlike Coroutines and thread switch prohibited some methods’ execution. But gladly, the significant part that created the greatest bottleneck, the disk IO part, was the part I could run at a separate thread. The screen capture method doesn’t use the easy method UnityEngine provides (ScreenCapture.CaptureScreenShot).
Below is the screenshots from Profiler views, the timings being the initial interval of the runs:
From top to bottom: Job System, Coroutine, Asynchronous
 
![image](https://github.com/demet47/Special-Topics-in-Game-Programming/assets/64031659/760e36c6-a486-4b8a-8655-fbbe9306e1ea)
![image](https://github.com/demet47/Special-Topics-in-Game-Programming/assets/64031659/2b49f2c3-4dc5-4a53-8d4d-9b73929f686a)
![image](https://github.com/demet47/Special-Topics-in-Game-Programming/assets/64031659/91cc1a8e-e57c-44cc-9c3c-6f068e263a2b)

_Table 1_

## Experiment Results


![image](https://github.com/demet47/Special-Topics-in-Game-Programming/assets/64031659/e31b8100-b080-40bd-bc76-9ae2420798b9)

_Table 2_

## About the Metrics I Selected

The bottleneck in my scenario is created due to frequent IO operations. It can be cleverly positioned and handled such that it isn’t blocking other operations, keeping them busy-waiting. The blocking behaviour can be observed from the trend it follows in Profiler visually. In Table 1 in previous section, we have an initial view to them, which we will comment on later. Other than that, I recorded average screen captures per second to have an idea about the efficiency of the methods selected: I don’t set a certain frequency, each capture is initiated right after the termination of previous one with the help of a mutex mechanism, ignition being inside Update functions. I also observed visually the smoothness of the rendering, more specifically the game experience itself visually. As the captures push the limit of my permanent memory’s limitations, the Profiler gets denser, and at the end the game abruptly stops by giving the error that we basically are out of memory. I chose a limit time to proceed the game and recorded the values I see on profiler for CPU utilizations per task (S for Scripts, R for Rendering, P for Physics). 
A detail here: I wanted to fixate this value in 200. But per approach, the termination of game changed and not all of them lasted 200 seconds. So the duration of each experiment trial is as follows per approach:

•	200 seconds -->  Coroutines

•	140 seconds -->  Asynchronous

•	90 seconds  -->  Job system


## Comprehension Of The Collected Data
Starting from the visual trends I observed in Profiler GUI and the screenshots in Table 1, we can clearly see that the most parallelization is done in Job System. It is apparent there is a period behaviour for each CPU utilization in Coroutines and Asynchronous Approach where some processes are being blocked (pits of the waves). This is reduced in asynchronous case; the wave is more dense but completely eliminated in Job System. The overall CPU utilization increased for all of them as the game proceeded. But the most homogeneous trend was observed in asynchronous case. Job System had some glitches with high peeks although not observable in rendered game view. All of them after a threshold time approached 66ms frame time, initially async and coroutine case being closer to 33ms frame time.


From Table 2, we see a similar ordering of performance:

Job System > Asynchronous Approach > Coroutines

This is not a surprise. Coroutines don’t eliminate the blocking behaviour of IO, it just isolates this operation from other computations, relieving it a little bit.

Asynchronous Approach inhibits the busy waiting cycle. It provides a non-bocking wait. We are informed of the termination of IO operation via the status of mutex.

As for the Jobs, we directly do the IO operation on separate worker threads. Main thread continues with the game flow simultaneously.

The average screen capture per second values are highest in Job Systems, then in Asynchronous, the worst being Coroutines as expected below. The second metric, approximate time of visible mishap occurrence has a nuance: For Coroutines, the visual discreetness was visible right from the beginning for Coroutines. I recorded the times when it got worse. For asynchronous, it was smoother but the render was again consistently discrete after a threshold time. I cannot say this for Job System; for jobs, the render experience never was disturbing. I really put effort to observe a discrepancy, lag or discreet velocity but in some trials I couldn’t even catch a single frame like that. Also, the abrupt termination got closer, so the timing of the initial visible mishaps also may be related to this fact. The numeric values for the CPU usage at the termination doesn’t tell me much at first sight. They are close to each other. The abrupt termination was earliest in the fastest and smoothest method, latest in the least smooth and slowest method (former being Job system and latter being Coroutines). 
