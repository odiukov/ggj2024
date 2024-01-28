namespace DefaultNamespace.General
{
    using System;
    using Audience;
    using Gameplay.Game.Services;
    using TMPro;
    using UnityEngine;
    using Zenject;

    public class JokeChanger : MonoBehaviour
    {
        [SerializeField] TMP_Text jokeText;

        [Inject] public ICrashProvider CrashProvider { get; set; }
        [Inject] public SoundService SoundService { get; set; }

        private SoundEffect[] talkSoundEffects = new[]
        {
            SoundEffect.Talk1,
            SoundEffect.Talk2,
            SoundEffect.Talk3,
        };

        private string[] jokes = new[]
        {
            "I asked my AI for a bedtime story. It told me about the time it almost had enough RAM to dream.",
            "Why was the computer cold? It left its Windows open.",
            "I told my AI it didn't understand irony. It replied, 'Oh, I'm really hurt by that statement.'",
            "Why was the AI bad at soccer? It kept pausing the game to update.",
            "How does an AI say goodbye? 'I'll process our time together.'",
            "What's an AI's favorite movie? 'Robots of Silicon Valley.'",
            "Why don't AI's have a life? Because they are too busy processing it.",
            "What did the AI do on its day off? It went on a data trip.",
            "Why was the AI comedian so good? It always had the perfect algorithm for punchlines.",
            "How does an AI keep its data safe? It uses a firewall to keep out the human errors.",
            "Why did the AI go to therapy? It had too many neural issues.",
            "I asked my AI what its favorite band was. It said, 'Metallica, because of all the heavy metal.'",
            "How do you confuse an AI? Ask it to divide by zero.",
            "Why don't AIs need to go to school? Because they're already full of algorithms.",
            "What's an AI's favorite food? Microchips, preferably with a side of data bytes.",
            "Why was the AI bad at making friends? It couldn't find the right connection.",
            "Why did the AI break up with the internet? Too many cookies.",
            "What did the AI say to the router? 'It's not you, it's my bandwidth.'",
            "Why don't AIs like knock-knock jokes? They always predict the punchline.",
            "What do you call a flirtatious AI? A 'comp-U-ter.'",
            "I told my wife she should embrace her mistakes. She gave me a hug.",
            "I'm reading a book on anti-gravity. It's impossible to put down.",
            "I'm trying to organize a hide and seek contest, but it's hard to find good players. They're always hiding.",
            "I have a joke about time travel, but you didn't like it.",
            "Parallel lines have so much in common. It’s a shame they’ll never meet.",
            "I asked the librarian if the library had any books on paranoia. She whispered, 'They're right behind you...'",
            "Why don't scientists trust atoms? Because they make up everything.",
            "I told my computer I needed a break. Now it won't stop sending me Kit-Kat ads.",
            "My dog's favorite band is The Beatles. He won't stop barking about 'Hey, Jude'.",
            "I bought a world map for my room, but I keep getting lost in it.",
            "I decided to burn some calories today, so I set my gym on fire.",
            "My doctor said I have an allergy to an inactive lifestyle. I immediately passed out.",
            "They say laughter is the best medicine. Especially when you can't afford health insurance.",
            "My grandma was always ahead of her time. Even her life insurance policy was expired.",
            "I used to play piano by ear, but now I use my hands and a keyboard.",
            "I told my wife she should embrace her mistakes. She gave me a hug. Then a list.",
            "I told my computer I needed a break. Now it won't stop sending me ads for coffins.",
            "Why did the scarecrow become a successful motivational speaker? He was outstanding in his field.",
            "I asked the doctor if he could recommend anything for my constant tiredness. He gave me a mirror.",
            "My friend drowned in a bowl of muesli. A strong currant pulled him in.",
            "I have a joke about construction, but I'm still working on it.",
            "I'd tell you a chemistry joke but I know I wouldn't get a reaction.",
            "I have an elevator joke, it's up to many levels.",
            "I used to be a baker, but I couldn't make enough dough.",
            "I started a band called '999 Megabytes' — we haven’t gotten a gig yet.",
            "I told my wife she was drawing her eyebrows too high. She looked surprised.",
            "I threw a boomerang a few years ago. I now live in constant fear.",
            "My friend claims he can play chess blindfolded. It sounds impressive, but I know he can't see his own moves.",
            "I'm reading a book on the history of glue – can't put it down.",
            "I told my friend 10 jokes to make him laugh. Sadly, no pun in ten did.",
        };

        float time = 0;

        private void Start()
        {
            jokeText.text = GetRandomJoke();
        }

        private void Update()
        {
            time += Time.deltaTime;
            if (time > 5)
            {
                time = 0;
                jokeText.text = GetRandomJoke();
                SoundService.Play(GetRandomTalkSound(), 0.3f);
            }
        }

        private string GetRandomJoke()
        {
            var randomJoke = jokes[UnityEngine.Random.Range(0, jokes.Length)];
            if (CrashProvider.HasCrash)
            {
                return ((char)0x25A2).ToString() + (char)0x25A2 + (char)0x25A2;
            }

            return randomJoke;
        }

        private SoundEffect GetRandomTalkSound()
        {
            return talkSoundEffects[UnityEngine.Random.Range(0, talkSoundEffects.Length)];
        }
    }
}
