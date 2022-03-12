
namespace Psychic;

public class Psychic : IPsychic
{

    public int LowerBound { get; set; }
    public int CurrentAttempt { get; set; }
    public int UpperBound { get; set; }
    public bool Complete { get; set; }
    public IEnumerable<int> AttemptHistory { get; set; }
    public int AttemptCount { get; set; }
    public void Higher()
    {
        //because it is higher, the lowest it can be becomes the last attempt made
        //ex: from 0 to 100, is it 50? no, higher? yes, 50 becomes the lowest
        this.LowerBound = this.CurrentAttempt;
        //transform the current attempt from its old value to a new one
        //this is done using the dynamic Upper bound and itself as values
        this.CurrentAttempt = this.CurrentAttempt + (UpperBound - this.CurrentAttempt) / 2;
        //new attempt added to the count
        this.AttemptCount++;
        //put the new attempt in attempts history
        this.AttemptHistory.Append<int>(this.CurrentAttempt);
    }
    public void Lower()
    {
        //same rules goes for the Lower() method
        this.UpperBound = this.CurrentAttempt;
        //transform the current attempt from its old value to a new one
        //this is done using the dynamic lower bound and itself as values
        this.CurrentAttempt = this.CurrentAttempt - (this.CurrentAttempt - LowerBound) / 2;
        //new attempt added to the count
        this.AttemptCount++;
        //put the new attempt in attempts history
        this.AttemptHistory.Append<int>(this.CurrentAttempt);
    }
    public void Correct()
    {
        //if the answer is correct, Complete becomes true...
        this.Complete = true;

    }



    public Psychic(int lowerBound, int upperBound)
    {
        //check first if the bounds are equal

        if (this.UpperBound == this.LowerBound)
        {
            //if yes, the answer is the bounds
            this.CurrentAttempt = lowerBound;
            //the solution is found, therefore Complete is true
            this.Complete = true;
            //we only have one attempt
            this.AttemptCount = 1;
            //the solution is put in attempts history
            this.AttemptHistory.Append<int>(this.CurrentAttempt);
        }
        //else, continue as normal...
        else
        {
            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
            //the first current attempt is the middle of the bounds
            this.CurrentAttempt = (lowerBound + upperBound) / 2;
            //Complete set to false as a default value
            this.Complete = false;
            //already have one attempt
            this.AttemptCount = 1;
            //put the first attempt in Attempts History
            this.AttemptHistory.Append<int>(this.CurrentAttempt);
        }

    }




}
