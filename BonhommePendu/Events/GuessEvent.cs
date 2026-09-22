using BonhommePendu.Models;

namespace BonhommePendu.Events
{
    // Un événement à créer chaque fois qu'un utilisateur essai une "nouvelle" lettre
    public class GuessEvent : GameEvent
    {
        public override string EventType { get { return "Guess"; } }
        // TODO: Compléter
        public GuessEvent(GameData gameData, char letter) {
            // TODO: Commencez par ICI
            var guessedLetterEvent = new GuessedLetterEvent(gameData, letter);
            var events = new List<GameEvent> { guessedLetterEvent };
            bool trouver = false;

            //Events = new List<GameEvent> { };
                //Events.Add(new GuessedLetterEvent(gameData, letter));

            for (int i = 0; i < gameData.Word.Length; i++)
            {
                if (gameData.HasSameLetterAtIndex(letter, i))
                {
                    events.Add(new RevealLetterEvent(gameData, letter, i));
                    trouver = true;
                }
            }
            if (trouver == false)
            {
                events.Add(new WrongGuessEvent(gameData));
            }
            Events = events;
        }
    }
}
