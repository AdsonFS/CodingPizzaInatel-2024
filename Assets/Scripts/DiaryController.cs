using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DiarieController
{
    public static int maskTasks = 0;
    public static string Note = "";
    public static string Tasks = "";
    private static List<string> diary = new()
    {
        "Eu estou perdido em uma ilha deserta. Eu preciso encontrar uma maneira de sobreviver.# I'm lost on a deserted island. I need to find a way to survive.",
        "Preciso matar minha sede. Procure por coco;#I need to quench my thirst. Look for coconuts;",
        "Preciso levar água comigo. Construa um Cantil com o coco#I need to take water with me. Build a Canteen with the coconut;",
        "Preciso de água limpa. Colete água potável;#I need clean water. Collect drinking water;",
        "Pronto, vamos procurar material na floresta.#Ready, let's look for material in the forest;",
        "Explore a floresta;#Explore the forest;",
        "Estou com fome. Pegue frutas nas árvores (aperte [X] em uma árvore frutífera);#I'm hungry. Pick fruits from the trees (press [X] on a fruit tree);",
        "Meu Deus, um Urso. Preciso de uma arma. Colete [N] gravetos;#My God, a Bear. I need a weapon. Collect [N] sticks;",
        "Pronto peguei os gravetos. Construa uma Lança; #Ready I got the sticks. Build a Spear;",
        "Boa sorte pra mim. Enfrente o Urso;#Good luck to me. Face the Bear;",
        "Que escuro aqui, não consigo enxergar. Colete [N] Gravetos e [N] Matinhos para construir uma tocha;#It's dark here, I can't see. Collect [N] Sticks and [N] Grass to build a torch;",
        "Que haja luz. Crie uma tocha;#Let there be light. Create a torch;",
        "Será que vou encontrar o Batman? Entre na caverna;#Will I find Batman? Enter the cave;",
        "Parece haver morcegos aqui dentro. Explore a caverna;#There seems to be bats in here. Explore the cave;",
        "Acho que essas pedras podem me ser útil. Colete as [N] pedras;#I think these stones can be useful to me. Collect the [N] stones;",
        "Legal com isso posso fazer uma marreta. Construa a Marreta;#Cool with this I can make a hammer. Build the Hammer;",
        "Acho que consigo quebrar essas pedras maiores com a Marreta. Quebre as pedras (aperte [X] nelas) e Colete N pedras;#I think I can break these larger stones with the Hammer. Break the stones (press X on them) and Collect [N] stones;",
        "Com isso posso fazer um machado. Construa um machado. #With this I can make an axe. Build an axe.",
        "Pronto, já tenho todo equipamento necessário para construir o barco, vamos coletar os materiais. Explore a ilha atrás de [N] madeiras e [N] pedras;#Ready, I already have all the necessary equipment to build the boat, let's collect the materials. Explore the island for [N] woods and [N] stones;",
        "Finalmente!!! Construa um BARCO!#Finally!!! Build a BOAT!",
    };


    private static List<Dictionary<ItemType, int>> nedeedItems = new()
    {
        { new Dictionary<ItemType, int> { { ItemType.STICK, 2 }, { ItemType.STONE, 1 } } },
        { new Dictionary<ItemType, int> { { ItemType.WOOD, 5 } } },
        { new Dictionary<ItemType, int> { { ItemType.FISH, 5 } } },
        { new Dictionary<ItemType, int> { { ItemType.STONE, 5 } } },
        { new Dictionary<ItemType, int> { { ItemType.GRASS, 5 } } },
        { new Dictionary<ItemType, int> { { ItemType.STICK, 5 } } },
        { new Dictionary<ItemType, int> { { ItemType.BERRY, 5 } } },
        { new Dictionary<ItemType, int> { { ItemType.POISONBERRY, 5 } } },
        { new Dictionary<ItemType, int> { { ItemType.BERRY, 5 } } },
        {  new Dictionary<ItemType, int> { { ItemType.WOOD, 5 } } }
    };

    private static List<int> dependencies = new() {
        -1,
        -1,
        1 << 0,
        1 << 1,
        1 << 2,
        1 << 3,
        1 << 3,
        1 << 4,
        1 << 5,
        1 << 6
    };

    public static string GetTasks => $"{Note}\n\n****************************************************\n\n{Tasks}\n";

    public static void UpdateTask()
    {
        Tasks = "";
        for (int i = 0; i < nedeedItems.Count; i++)
        {
            if ((maskTasks & (1 << i)) != 0) continue;
            if (dependencies[i] == -1 || ((maskTasks & (1 << i)) == 0 && (dependencies[i] & maskTasks) == dependencies[i]))
            {
                Tasks += $"- {diary[i].Split("#")[0]}\n\n";
            }
        }
    }
    public static void CheckDay(List<Item> items)
    {
        bool update = false;
        for (int i = 0; i < nedeedItems.Count; i++)
        {
            bool ok = true;
            if ((maskTasks & (1 << i)) != 0) continue;
            foreach (var item in nedeedItems[i])
            {
                if (items.Count(x => x.type == item.Key) < item.Value)
                    ok = false;
                continue;
            }
            if (ok) { maskTasks |= 1 << i; update = true; }
        }
        if (update) UpdateTask();
    }
}
