Load testing. 

The load test I created with using a JMeter tool with a following parameters:

Parallel user count - 100 (jmeter_test1.png)
Number of the test run loop - 5 (jmeter_test1.png)
Endpoint tested - /public-api/todos/9 (jmeter_test2.png)

Results are (jmeter_test3.png):

Average request time ~ 1.9 sec. 
Max request time ~ 21 sec. 
Error rate ~ 53%


