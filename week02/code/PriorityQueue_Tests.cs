using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario:
    // Add Low with priority 1, High with priority 10,
    // and Medium with priority 5.
    //
    // Expected Result:
    // Items should be removed in priority order:
    // High, Medium, Low.
    //
    // Test Result:
    // Initially failed. High was returned correctly first,
    // but High was returned again instead of Medium.
    //
    // Defect(s) Found:
    // The highest-priority item was found correctly,
    // but it was not removed from the queue after being returned.
    //
    // Final Result:
    // Passed after fixing Dequeue to remove the selected item.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("Medium", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario:
    // Add two items with the same highest priority.
    //
    // Expected Result:
    // When priorities are the same, the item added first
    // should be removed first (FIFO).
    //
    // Test Result:
    // Initially failed. Second was returned before First.
    //
    // Defect(s) Found:
    // When two items had the same priority, the most recently
    // added item was selected instead of the first item added.
    //
    // Final Result:
    // Passed after fixing the comparison so equal priorities
    // keep FIFO order.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 10);
        priorityQueue.Enqueue("Second", 10);
        priorityQueue.Enqueue("Low", 1);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario:
    // Attempt to dequeue from an empty priority queue.
    //
    // Expected Result:
    // An InvalidOperationException should be thrown
    // with the message "The queue is empty."
    //
    // Test Result:
    // Passed.
    //
    // Defect(s) Found:
    // None. The correct exception type and message were returned.
    //
    // Final Result:
    // Passed.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        var exception =
            Assert.ThrowsException<InvalidOperationException>(
                () => priorityQueue.Dequeue()
            );

        Assert.AreEqual(
            "The queue is empty.",
            exception.Message
        );
    }
}