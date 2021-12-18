using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    ////////////////////////////////SUPER RARE//////////////////////////////////

    //summary
    public static string[] superRareItemsTexts;

    string coronadoText = "It belongs in a museum!";
    string mickyMantleText = "Wow! This is worth a lot of cash!";
    string obamasBirthText = "So that's where it's been all this time!";
    string shellyMiscavigeText = "Huh I guess she is still alive";
    string ufoText = "Close encounters of the \"turd\" kind am I right?";
    string whaleText = "He's Moby Dick's nephew and a famous Souncloud rapper";


    //headings
    public static string[] superRareItemsHeadings;

    string coronadoHeading = "Cross of Coronado";
    string mickeyMantleHeading = "Mickey Mantle Rookie Card";
    string obamasBirthHeading = "Obama's Birth Certificate";
    string shellyMiscavigeHeading = "Shelly Miscavige";
    string ufoHeading = "Alien Ship";
    string whaleHeading = "Lil Dick";

    //art
    public static Sprite[] superRareItemsArt;

    public Sprite coronadoArt;
    public Sprite mickeyMantleArt;
    public Sprite obamasBirthArt;
    public Sprite shellyMiscavigeArt;
    public Sprite ufoArt;
    public Sprite whaleArt;

    //coins
    public static int[] superRareItemsCoins;

    int coronadoCoins = 100;
    int mickeyMantleCoins = 50;
    int obamasBirthCoins = 30;
    int shellyMiscavigeCoins = 30;
    int ufoCoins = 75;
    int whaleCoins = 40;
    ////////////////////////////////RARE//////////////////////////////////

    //summary
    public static string[] rareItemsTexts;
    
    
    string weddingRingText = "Someone's probably really missing this. Let's pawn it! Maybe clean it first";
    string indianPennyText = "Hey that's not Abraham Lincoln!";
    string hairBallText = "It's been clogging the drain for years!";
    string grandpasDenturesText = "Hurry rinse them off! Grandma made corn on the cob for supper!";
    string unwrappedCandyText = "Score! Free candy!";
    string amuletText = "This amulet was forged long ago by a tribe of dark elves. Just kidding it's from Sears";
    string robotText = "Its primary function is to give high-fives";
    string pesosText = "Holy crap! That's like $8 usd!";
    string wineText = "Oh perfect timing I just can't today!";


    string kaleText = "Ew! Gross!";
    string lindsayLohanText = "Ew! Lindsay Lohan is mucking up my sewage!";
    string plutoniumText = "Weird question but is your skin melting off too?";
    string monsterText = "Ahhhh! I'm wearing white pants!";

    //heading
    public static string[] rareItemsHeadings;

    string weddingRingHeading = "Wedding Ring";
    string indianPennyHeading = "Indian Head Penny";
    string hairBallHeading = "Giant Hairball";
    string grandpasDenturesHeading = "Grandpa's Dentures";
    string unwrappedCandyHeading = "Unwrapped Lollipop";
    string amuletHeading = "Amulet of Zanthinar";
    string robotHeading = "High-Fiving Robot";
    string pesosHeading = "1 Million Pesos";
    string wineHeading = "Bottle of Wine";

    string kaleHeading = "Kale";
    string lindsayLohanHeading = "Lindsay Lohan";
    string plutoniumHeading = "Plutonium";
    string monsterHeading = "Poop Monster";


    //art
    public static Sprite[] rareItemsArt;

   
    public Sprite weddingRingArt;
    public Sprite indianPennyArt;
    public Sprite hairBallArt;
    public Sprite grandpasDenturesArt;
    public Sprite unwrappedCandyArt;
    public Sprite amuletArt;
    public Sprite robotArt;
    public Sprite pesosArt;
    public Sprite wineArt;

    public Sprite kaleArt;
    public Sprite lindsayLohanArt;
    public Sprite plutoniumArt;
    public Sprite monsterArt;

    //coins
    public static int[] rareItemsCoins;

    int weddingRingCoins = 10;
    int indianPennyCoins = 10;
    int hairBallCoins = 3;
    int grandpasDenturesCoins = 3;
    int unwrappedCandyCoins = 3;
    int amuletCoins = 5;
    int robotCoins = 7;
    int pesosCoins = 5;
    int wineCoins = 5;

    int kaleCoins = -3;
    int lindsayLohanCoins = -5;
    int plutoniumCoins = -10;
    int monsterCoins = -5;

    /////////////////////////////////ITEM///////////////////////////////////

    //summary
    public static string[] itemsTexts;

    string catSkeletonText = "Fluffy? I thought she just ran away :(";
    string pirateHatText = "Throw it back it belongs in there";
    string liveStrongText = "Hey remember these?";
    string nokiaText = "Hey look it still works!";
    string babyAlligatorText = "It's quite possible you will see him later";
    string americanDreamText = "*INSERT POLITICAL COMMENTARY*";
    string zuneText = "Hey remember these? Me neither";
    string fallout76Text = "Throw it back it's trash";
    string johnnyDeppText = "Leave him be he's napping";
    string gwenethPaltrowText = "She must be restocking her Goop ingredients";
    string ratText = "I'm gonna name him Carlos";
    string squidText = "Looks like someone's having calamari for dinner!"; 
    string ghostbustersDVDText = "You're gonna want to throw that back in";
    string clevelandText = "How'd they fit the entire city in there?";
    string goldenCorralText = "No thanks I already have diarrhea";
    string carrotTopText = "Could someone please gouge out my eyeballs?";
    string shrekText = "\"I doont remembuh this many turds floating around in muh swamp!\"";
    string puppiesText = "Thank heavens we found them before...oh wait nevermind";
    string frogText = "Hey there sailor!";
    string stonesText = "Whoever gets the most skips wins a firm handshake";
    string cornText = "How clich\u00e9!";
    string eggsacText = "I don't care what made it I just want some breakfast!";
    string turtlesText = "I just can't tell them apart without colored bandanas";
    string strawText = "Uh no thanks I only use straws made from recycled hemp *sniffs own farts*";
    string waldoText = "Sure when I wasn't looking for him";
    string cyclopsText = "I bet this guy has a real \"eye\" for detail";
    string shroomText = "If you eat it maybe you'll grow bigger? Or probably you'll just die";
    string speedoText = "Somewhere a hairy European man is weeping";
    string radioText = "It's not only a clock but get this: it's a radio!";
    string pasteText = "You gonna eat that?";
    string bumText = "Finally someone to perform my experiments on!";
    string cosbyText = "If he offers you a drink take it. Don't be rude!";
    string balloonText = "This can't be a good sign";



    //heading
    public static string[] itemsHeadings;

    string catSkeletonHeading = "Cat Skeleton";
    string pirateHatHeading = "Pittsburgh Pirates Hat";
    string liveStrongHeading = "Livestrong Bracelet";
    string nokiaHeading = "Old Nokia Phone";
    string babyAlligatorHeading = "Alligator";
    string americanDreamHeading = "The American Dream";
    string zuneHeading = "Microsoft Zune";
    string fallout76Heading = "Fallout 76 Game";
    string johnnyDeppHeading = "Johnny Depp";
    string gwenethPaltrowHeading = "Gweneth Paltrow";
    string ratHeading = "Large Rat";
    string squidHeading = "Dead Squid";
    string ghostbustersDVDHeading = "Ghostbusters 2016 DVD";
    string clevelandHeading = "Cleveland, Ohio";
    string goldenCorralHeading = "Golden Corral Coupon";
    string carrotTopHeading = "Carrot Top";
    string shrekHeading = "Shrek";
    string puppiesHeading = "Sack Full of Puppies";
    string frogHeading = "Gay Frog";
    string stonesHeading = "Skipping Stones";
    string cornHeading = "Corn";
    string eggsacHeading = "Mysterious Egg Sac";
    string turtlesHeading = "Family of Turtles";
    string strawHeading = "Plastic Straw";
    string waldoHeading = "Waldo";
    string cyclopsHeading = "Cyclops";
    string shroomHeading = "Mushroom";
    string speedoHeading = "Speedo";
    string radioHeading = "Clock Radio";
    string pasteHeading = "Paste";
    string bumHeading = "Homeless Man";
    string cosbyHeading = "Bill Cosby";
    string balloonHeading = "Red Balloon";

    //art
    public static Sprite[] itemsArt;

    public Sprite catSkeletonArt;
    public Sprite pirateHatArt;
    public Sprite liveStrongArt;
    public Sprite nokiaArt;
    public Sprite babyAlligatorArt;
    public Sprite americanDreamArt;
    public Sprite zuneArt;
    public Sprite fallout76Art;
    public Sprite johnnyDeppArt;
    public Sprite gwenethPaltrowArt;
    public Sprite ratArt;
    public Sprite squidArt;
    public Sprite ghostbustersDVDArt;
    public Sprite clevelandArt;
    public Sprite goldenCorralArt;
    public Sprite carrotTopArt;
    public Sprite shrekArt;
    public Sprite puppiesArt;
    public Sprite frogArt;
    public Sprite stonesArt;
    public Sprite cornArt;
    public Sprite eggsacArt;
    public Sprite turtlesArt;
    public Sprite strawArt;
    public Sprite waldoArt;
    public Sprite cyclopsArt;
    public Sprite shroomArt;
    public Sprite speedoArt;
    public Sprite radioArt;
    public Sprite pasteArt;
    public Sprite bumArt;
    public Sprite cosbyArt;
    public Sprite balloonArt;

    ///////////////////////////////NUGGET////////////////////////////////////

    //summary
    public static string[] nuggetTexts;

    string nugget1Text = "Nice! Find two more to win a prize!";
    string nugget2Text = "Sweet! Only one more and you win a prize!";
    string nugget3Text = "Yay three golden nuggets! You win a prize!";

    //heading
    public static string nuggetHeading = "Golden Nugget";

    //art
    public static Sprite nuggetArt;

    public Sprite goldenNuggetArt;

    //////////////////////////////SHARK////////////////////////////////////

    //summary
    /*public static string shartText = "Uh oh! There go your nuggets!";

    //heading
    public static string shartHeading = "Shart";

    //art
    public static Sprite shartArt;

    public Sprite shartheadArt;*/

    private void Awake()
    {
        ////////////////////////////////SUPER RARE//////////////////////////////////

        superRareItemsTexts = new string[]
        {
            coronadoText,
            mickyMantleText,
            obamasBirthText,
            shellyMiscavigeText,
            ufoText,
            whaleText
        };
        superRareItemsHeadings = new string[]
        {
            coronadoHeading,
            mickeyMantleHeading,
            obamasBirthHeading,
            shellyMiscavigeHeading,
            ufoHeading,
            whaleHeading
        };
        superRareItemsArt = new Sprite[]
        {
            coronadoArt,
            mickeyMantleArt,
            obamasBirthArt,
            shellyMiscavigeArt,
            ufoArt,
            whaleArt
        };
        superRareItemsCoins = new int[]
        {
            coronadoCoins,
            mickeyMantleCoins,
            obamasBirthCoins,
            shellyMiscavigeCoins,
            ufoCoins,
            whaleCoins
        };

        ////////////////////////////////RARE//////////////////////////////////
        ///
        rareItemsTexts = new string[]
        {
            weddingRingText,
            indianPennyText,
            hairBallText,
            grandpasDenturesText,
            unwrappedCandyText,
            amuletText,
            robotText,
            pesosText,
            wineText,

            kaleText,
            lindsayLohanText,
            plutoniumText,
            monsterText,
        };
        rareItemsHeadings = new string[]
        {
            weddingRingHeading,            
            indianPennyHeading,
            hairBallHeading,
            grandpasDenturesHeading,
            unwrappedCandyHeading,
            amuletHeading,
            robotHeading,
            pesosHeading,
            wineHeading,

            kaleHeading,
            lindsayLohanHeading,
            plutoniumHeading,
            monsterHeading
        };
        rareItemsArt = new Sprite[]
        {
            weddingRingArt,            
            indianPennyArt,
            hairBallArt,
            grandpasDenturesArt,
            unwrappedCandyArt,
            amuletArt,
            robotArt,
            pesosArt,
            wineArt,

            kaleArt,
            lindsayLohanArt,
            plutoniumArt,
            monsterArt
        };
        rareItemsCoins = new int[]
        {
            weddingRingCoins,           
            indianPennyCoins,
            hairBallCoins,
            grandpasDenturesCoins,
            unwrappedCandyCoins,
            amuletCoins,
            robotCoins,
            pesosCoins,
            wineCoins,

            kaleCoins,
            lindsayLohanCoins,
            plutoniumCoins,
            monsterCoins
        };

        /////////////////////////////////ITEM///////////////////////////////////

        itemsTexts = new string[] 
        {
            catSkeletonText,
            pirateHatText,
            liveStrongText,
            nokiaText,
            babyAlligatorText,
            americanDreamText,
            zuneText,
            fallout76Text,
            johnnyDeppText,
            gwenethPaltrowText,
            ratText,
            squidText,
            ghostbustersDVDText,
            clevelandText,
            goldenCorralText,
            carrotTopText,
            shrekText,
            puppiesText,
            frogText,
            stonesText,
            cornText,
            eggsacText,
            turtlesText,
            strawText,
            waldoText,
            cyclopsText,
            shroomText,
            speedoText,
            radioText,
            pasteText,
            bumText,
            cosbyText,
            balloonText
        };

        itemsHeadings = new string[]
        {
            catSkeletonHeading,
            pirateHatHeading,
            liveStrongHeading,
            nokiaHeading,
            babyAlligatorHeading,
            americanDreamHeading,
            zuneHeading,
            fallout76Heading,
            johnnyDeppHeading,
            gwenethPaltrowHeading,
            ratHeading,
            squidHeading,
            ghostbustersDVDHeading,
            clevelandHeading,
            goldenCorralHeading,
            carrotTopHeading,
            shrekHeading,
            puppiesHeading,
            frogHeading,
            stonesHeading,
            cornHeading,
            eggsacHeading,
            turtlesHeading,
            strawHeading,
            waldoHeading,
            cyclopsHeading,
            shroomHeading,
            speedoHeading,
            radioHeading,
            pasteHeading,
            bumHeading,
            cosbyHeading,
            balloonHeading
        };
        itemsArt = new Sprite[]
        {
            catSkeletonArt,
            pirateHatArt,
            liveStrongArt,
            nokiaArt,
            babyAlligatorArt,
            americanDreamArt,
            zuneArt,
            fallout76Art,
            johnnyDeppArt,
            gwenethPaltrowArt,
            ratArt,
            squidArt,
            ghostbustersDVDArt,
            clevelandArt,
            goldenCorralArt,
            carrotTopArt,
            shrekArt,
            puppiesArt,
            frogArt,
            stonesArt,
            cornArt,

            eggsacArt,
            turtlesArt,
            strawArt,
            waldoArt,
            cyclopsArt,
            shroomArt,
            speedoArt,
            radioArt,
            pasteArt,
            bumArt,
            cosbyArt,
            balloonArt
        };

        ///////////////////////////////NUGGET////////////////////////////////////

        nuggetTexts = new string[]
        {
            nugget1Text,
            nugget2Text,
            nugget3Text
        };
        nuggetArt = goldenNuggetArt;
    }
}
