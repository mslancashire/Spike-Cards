using System.Collections.Generic;

namespace Cards.Data.Source;

public sealed class GreekCardNames : List<CardName>
{
    private static GreekCardNames greekNamesInstance = new GreekCardNames();

    static GreekCardNames()
    { }

    private GreekCardNames()
        : base()
    {
        // https://en.wikipedia.org/wiki/List_of_Greek_mythological_figures
        // this.Add(new CardName { Name = "", Category = "", Description = "" });

        // TODO: Add main card names.

        Add(new CardName { Name = "Aether", Category = "Primordial Deity", Description = "The god of the upper atmosphere and light." });
        Add(new CardName { Name = "Ananke", Category = "Primordial Deity", Description = "The goddess of inevitability, compulsion, and necessity." });
        Add(new CardName { Name = "Chaos", Category = "Primordial Deity", Description = "The nothingness from which all else sprang. Described as a void." });
        Add(new CardName { Name = "Chronus", Category = "Primordial Deity", Description = "The god of time. Not to be confused with the Titan Cronus (Kronos), the father of Zeus, Poseidon and Hades." });
        Add(new CardName { Name = "Erebus", Category = "Primordial Deity", Description = "The god of darkness and shadow." });
        Add(new CardName { Name = "Eros", Category = "Primordial Deity", Description = "The god of love and attraction." });
        Add(new CardName { Name = "Hypnos", Category = "Primordial Deity", Description = "The personification of sleep." });
        Add(new CardName { Name = "Nesoi", Category = "Primordial Deity", Description = "The goddesses of the islands and sea." });
        Add(new CardName { Name = "Uranus", Category = "Primordial Deity", Description = "The god of the heavens (Father Sky); father of the Titans." });
        Add(new CardName { Name = "Gaia", Category = "Primordial Deity", Description = "Personification of the Earth (Mother Earth); mother of the Titans." });
        Add(new CardName { Name = "Ourea", Category = "Primordial Deity", Description = "The gods of mountains." });
        Add(new CardName { Name = "Phanes", Category = "Primordial Deity", Description = "The god of procreation in the Orphic tradition." });
        Add(new CardName { Name = "Pontus", Category = "Primordial Deity", Description = "The god of the sea, father of the fish and other sea creatures." });
        Add(new CardName { Name = "Tartarus", Category = "Primordial Deity", Description = "The god of the deepest, darkest part of the underworld, the Tartarean pit (which is also referred to as Tartarus itself)." });
        Add(new CardName { Name = "Thalassa", Category = "Primordial Deity", Description = "Personification of the sea and consort of Pontus." });
        Add(new CardName { Name = "Thanatos", Category = "Primordial Deity", Description = "God of Death. Brother to Hypnos (Sleep) and in some cases Moros (Doom)" });
        Add(new CardName { Name = "Hemera", Category = "Primordial Deity", Description = "The goddess of day." });
        Add(new CardName { Name = "Nyx", Category = "Primordial Deity", Description = "The goddess of night." });
        Add(new CardName { Name = "Nemesis", Category = "Primordial Deity", Description = "The goddess of retribution." });
        Add(new CardName { Name = "Coeus", Category = "Twelve Titans", Description = "Titan of intellect and the axis of heaven around which the constellations revolved." });
        Add(new CardName { Name = "Crius", Category = "Twelve Titans", Description = "The least individualized of the Twelve Titans, he is the father of Astraeus, Pallas, and Perses." });
        Add(new CardName { Name = "Cronus", Category = "Twelve Titans", Description = "The leader of the Titans, who overthrew his father Uranus only to be overthrown in turn by his son, Zeus. Not to be confused with Chronos, the god of time." });
        Add(new CardName { Name = "Hyperion", Category = "Twelve Titans", Description = "Titan of light. With Theia, he is the father of Helios (the sun), Selene (the moon), and Eos (the dawn)." });
        Add(new CardName { Name = "Iapetus", Category = "Twelve Titans", Description = "Titan of mortality and father of Prometheus, Epimetheus, Menoetius, and Atlas." });
        Add(new CardName { Name = "Mnemosyne", Category = "Twelve Titans", Description = "Titaness of memory and remembrance, and mother of the Nine Muses." });
        Add(new CardName { Name = "Oceanus", Category = "Twelve Titans", Description = "Titan of the all-encircling river Oceans around the earth, the fount of all the Earth's fresh-water." });
        Add(new CardName { Name = "Phoebe", Category = "Twelve Titans", Description = "Titaness of the 'bright' intellect and prophecy, and consort of Koios." });
        Add(new CardName { Name = "Rhea", Category = "Twelve Titans", Description = "Titaness of fertility, motherhood and the mountain wilds. She is the sister and consort of Cronus, and mother of Zeus, Hades, Poseidon, Hera, Demeter, and Hestia." });
        Add(new CardName { Name = "Tethys", Category = "Twelve Titans", Description = "Titaness of fresh-water, and the mother of the rivers, springs, streams, fountains, and clouds." });
        Add(new CardName { Name = "Theia", Category = "Twelve Titans", Description = "Titaness of sight and the shining light of the clear blue sky. She is the consort of Hyperion, and mother of Helios, Selene, and Eos." });
        Add(new CardName { Name = "Themis", Category = "Twelve Titans", Description = "Titaness of divine law and order." });
        Add(new CardName { Name = "Asteria", Category = "Titan", Description = "Titaness of nocturnal oracles and falling stars." });
        Add(new CardName { Name = "Astraeus", Category = "Titan", Description = "Titan of dusk, stars, and planets, and the art of astrology." });
        Add(new CardName { Name = "Atlas", Category = "Titan", Description = "Titan forced to carry the heavens upon his shoulders by Zeus. Also Son of Iapetus." });
        Add(new CardName { Name = "Aura", Category = "Titan", Description = "Titaness of the breeze and the fresh, cool air of early morning." });
        Add(new CardName { Name = "Clymene", Category = "Titan", Description = "Titaness of renown, fame, and infamy, and wife of Iapetus." });
        Add(new CardName { Name = "Dione", Category = "Titan", Description = "Titaness of the oracle of Dodona." });
        Add(new CardName { Name = "Helios", Category = "Titan", Description = "Titan of the sun and guardian of oaths." });
        Add(new CardName { Name = "Selene", Category = "Titan", Description = "Titaness of the moon." });
        Add(new CardName { Name = "Eos", Category = "Titan", Description = "Titaness of the dawn." });
        Add(new CardName { Name = "Epimetheus", Category = "Titan", Description = "Titan of afterthought and the father of excuses." });
        Add(new CardName { Name = "Eurybia", Category = "Titan", Description = "Titaness of the mastery of the seas and consort of Krios." });
        Add(new CardName { Name = "Eurynome", Category = "Titan", Description = "Titaness of water-meadows and pasturelands, and mother of the three Charites by Zeus." });
        Add(new CardName { Name = "Lelantos", Category = "Titan", Description = "Titan of air and the hunter's skill of stalking prey. He is the male counterpart of Leto." });
        Add(new CardName { Name = "Leto", Category = "Titan", Description = "Titaness of motherhood and mother of the twin Olympians, Artemis and Apollo." });
        Add(new CardName { Name = "Menoetius", Category = "Titan", Description = "Titan of violent anger, rash action, and human mortality. Killed by Zeus." });
        Add(new CardName { Name = "Metis", Category = "Titan", Description = "Titaness of good counsel, advice, planning, cunning, craftiness, and wisdom. Mother of Athena." });
        Add(new CardName { Name = "Ophion", Category = "Titan", Description = "An elder Titan, in some versions of the myth he ruled the Earth with his consort Eurynome before Cronus overthrew him. Another account describes him as a snake, born from the 'World Egg'" });
        Add(new CardName { Name = "Pallas", Category = "Titan", Description = "Titan of warcraft. He was killed by Athena during the Titanomachy." });
        Add(new CardName { Name = "Perses", Category = "Titan", Description = "Titan of destruction." });
        Add(new CardName { Name = "Prometheus", Category = "Titan", Description = "Titan of forethought and crafty counsel, and creator of mankind." });
        Add(new CardName { Name = "Styx", Category = "Titan", Description = "Titaness of the Underworld river Styx and personification of hatred." });
    }

    public static GreekCardNames Instance
    {
        get { return greekNamesInstance; }
    }
}

public class CardName
{
    public string Name;
    public string Description;
    public string Category;
}