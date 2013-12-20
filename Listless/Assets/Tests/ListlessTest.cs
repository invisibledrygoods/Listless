using UnityEngine;
using System.Collections.Generic;
using Require;
using Shouldly;
using Listless;

public class ListlessTest : TestBehaviour
{
    List<int> it;
    int chosen;
    List<int> chosens;
    Dictionary<int, int> histogram;

    public override void Spec()
    {
        Scenario("uses Listless extension methods");

        Given("it contains numbers 0 through 2")
            .When("index 0 and 1 are swapped")
            .Then("index 0 should be 1")
            .And("index 1 should be 0")
            .Because("swap should swap 2 items");

        Given("it contains numbers 1 through 5")
            .When("a random item is chosen")
            .Then("it should contain the item")
            .Because("Random() should return an item contained in the list");

        Given("it contains numbers 1 through 5")
            .When("a random item is chosen 1000 times")
            .Then("no item should be chosen more than 250 times")
            .And("no item should be chosen less than 150 times")
            .Because("Random() should return fairly random results");

        Given("it contains numbers 1 through 5")
            .When("3 random items are chosen")
            .Then("it should return 3 items")
            .And("it should contain all the items")
            .Because("Random(k) should return k items contained in the list");

        Given("it contains numbers 1 through 5")
            .When("3 random items are chosen")
            .Then("none of the items should be duplicates")
            .Because("Random(k) should never return the same item twice");

        Given("it contains numbers 1 through 5")
            .When("3 random items are chosen 1000 times")
            .Then("no item should be chosen more than 750 times")
            .And("no item should be chosen less than 450 times")
            .Because("Random(k) should return fairly random results");

        Given("it contains numbers 1 through 5")
            .When("3 random items are chosen with replacement")
            .Then("it should return 3 items")
            .And("it should contain all the items")
            .Because("RandomWithReplacement(k) should return k items contained in the list");

        Given("it contains numbers 1 through 5")
            .When("100 random items are chosen with replacement")
            .Then("it should return 100 items")
            .Because("RandomWithReplacement(k) can return duplicates");

        Given("it contains numbers 1 through 5")
            .When("3 random items are chosen 1000 times with replacement")
            .Then("no item should be chosen more than 750 times")
            .And("no item should be chosen less than 450 times")
            .Because("RandomWithReplacement(k) should return fairly random results");

        Given("it contains numbers 1 through 5")
            .When("it is shuffled 1000 times")
            .Then("no item should be in a position more than 250 times")
            .And("no item should be in a position less than 150 times")
            .Because("shuffle should be pretty random");
    }

    public void ItContainsNumbers__Through__(int start, int finish)
    {
        it = new List<int>();
        histogram = new Dictionary<int, int>();

        for (int i = start; i <= finish; i++)
        {
            it.Add(i);
            histogram[i] = 0;
        }
    }

    public void Index__And__AreSwapped(int a, int b)
    {
        it.Swap(a, b);
    }

    public void ARandomItemIsChosen()
    {
        chosen = it.Random();
    }

    public void __RandomItemsAreChosen(int count)
    {
        chosens = it.Random(count);
    }

    public void ARandomItemIsChosen__Times(int times)
    {
        for (int i = 0; i < times; i++)
        {
            histogram[it.Random()]++;
        }
    }

    public void __RandomItemsAreChosen__Times(int count, int times)
    {
        for (int i = 0; i < times; i++)
        {
            foreach (int item in it.Random(count))
            {
                histogram[item]++;
            }
        }
    }

    public void Index__ShouldBe__(int index, int expected)
    {
        it[index].ShouldBe(expected);
    }

    public void ItShouldContainTheItem()
    {
        it.ShouldContain(chosen);
    }

    public void NoItemShouldBeChosenMoreThan__Times(int times)
    {
        foreach (int count in histogram.Values)
        {
            count.ShouldBeLessThan(times);
        }
    }

    public void NoItemShouldBeChosenLessThan__Times(int times)
    {
        foreach (int count in histogram.Values)
        {
            count.ShouldBeGreaterThan(times);
        }
    }

    public void ItShouldReturn__Items(int count)
    {
        chosens.Count.ShouldBe(count);
    }

    public void ItShouldContainAllTheItems()
    {
        foreach (int chosen in chosens)
        {
            it.ShouldContain(chosen);
        }
    }

    public void NoneOfTheItemsShouldBeDuplicates()
    {
        for (int i = 0; i < chosens.Count; i++)
        {
            for (int j = 0; j < chosens.Count; j++)
            {
                if (i == j)
                {
                    continue;
                }

                i.ShouldNotBe(j);
            }
        }
    }
}
