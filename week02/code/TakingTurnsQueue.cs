/// <summary>
/// This queue is circular. When people are added via AddPerson, then they are added to the
/// back of the queue (per FIFO rules). When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.
/// Each person stays in the queue while they still have turns.
/// A turns value of 0 or less means infinite turns.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add new people to the queue with a name and number of turns.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them.
    /// The person goes to the back of the queue again unless
    /// they have no more turns left.
    /// A turns value of 0 or less means infinite turns.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        // Zero or a negative number means infinite turns.
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        else
        {
            // Use one turn.
            person.Turns--;

            // If the person still has turns left,
            // put them back at the end of the queue.
            if (person.Turns > 0)
            {
                _people.Enqueue(person);
            }
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}