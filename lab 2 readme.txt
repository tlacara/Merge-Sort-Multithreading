Part 1

1.
Array Size 10: Single Thread: 00.00, Multi Thread: 00.34
Array Size 100: Single Thread: 00.00, Multi Thread: 00.18
Array Size 1000: Single Thread: 00.00, MultiThread: 00.37
Array Size 10000: Single Thread: 00.00, Multi Thread: 00.17
Array Size 100000: Single Thread: 00.11, Multi Thread: 00.25
Array Size 1000000: Single Thread: 00.75, Multi Thread: 1.44
Array Size 10000000: Single Thread: 6.93, Multi Thread: 6.76
Array Size 100000000: SIngle Thread: 1:12.38, Multi Thread: 1:25.61

2. My machine has 4 cores so I was expecting a speed up factor of roughly 4.

3. I did not achieve the speed-up I was expecting, this could be due to my algorithm no being optimized or my multi thread 
methods simply not working as expected. It could also be due to the fact that I wasn't using the optimal amount of threads
meaning I was using too many threads and I had a large overhead cost.

4. Number of Threads(left) vs Speed up Factor(right) for sample size of 1 milion
2=1.54
4=1.67
10=1.47
25=0.71
50=0.368
100=0.264

As we can see we had the highest speedup factor when the number of threads equaled the number of cores. As we increase the 
thread count the speed up factor decreases significanly.



Part 2


A: with 1000 samples I got an estimate of 3.084 which is 98% accurate.To be accurate to 3 decimal places,I needed 100000 samples.

Speed up Factors based on sample size with 4 cores

10^3=0.0203
10^4=0.242
10^5=1.1849
10^6=1.2957
10^7=1.383
10^8= memory out of range

Questions:

1. I've learned that splitting up work between threads can make computations much faster if it's done correctly
and with the right combination of sample size and thread. For very small sample sizes, single threads are magnitudes faster at
computations and at larger sample sizes, multi thread computations tend to be faster. The number of threads also makes a huge
difference as the overhead costs are quite apparent when trying to do computations for small sample sizes with a lage number of 
threads.

2. When designing concurrent code, it's very important to find the right combination of thread counts in order to fully maximize
concurrency. I think it ill always be better to use single threading for smaller computations, but for larger ones we have 
to look at the number of cores our machine has and find an optimum number of threads we can use without getting negative impacts 
from overhead costs.

3. Considering the fact that I was only able to get it accurate to 3 decimal places with 10^7 samples, I would estimate that we need at least
10^15 samples to get it accurate to 7 decimal places. I think th eMonte Carlo method is an efficient way to calculate the the value of pi to a 
very high accuracy since we could continously improve the accuracy by increasing our sample size.