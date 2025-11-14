using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result:  
    // Scenario: Enqueue items A(1), B(3), C(2), D(3). Dequeue four times.
    // Expected Result: Highest priority items come out first in FIFO order: B, D, C, A.
    // Defect(s) Found:
    // - The priority comparison used '>=' instead of '>' which caused the LAST highest-priority
    //   item to be selected instead of the FIRST.
    // - This broke FIFO behavior for items with the same priority.
    // - Dequeue returned D before B, which is incorrect because B was enqueued first.
    public void TestPriorityQueue_1()
    
    {
         var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3); // Highest priority
        pq.Enqueue("C", 2);
        pq.Enqueue("D", 3); // Same priority as B

        // First dequeue → B (first among highest priority)
        Assert.AreEqual("B", pq.Dequeue());
        // Second dequeue → D (next among highest priority)
        Assert.AreEqual("D", pq.Dequeue());
        // Third dequeue → C
        Assert.AreEqual("C", pq.Dequeue());
        // Fourth dequeue → A
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: 
    // Expected Result:  
    // Scenario: Enqueue items A(1), B(3), C(2), D(3). Dequeue four times.
    // Expected Result: Highest priority items come out first in FIFO order: B, D, C, A.
    // Defect(s) Found:
    // - Dequeue did not throw an InvalidOperationException when the queue was empty.
    // - The exception message did not match the required text: "The queue is empty."
    // - This could lead to unhandled exceptions or incorrect error handling in client code.
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception type {e.GetType()} caught: {e.Message}");
        }
    }
}


