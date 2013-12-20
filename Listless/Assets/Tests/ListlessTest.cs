using UnityEngine;
using System.Collections.Generic;
using Require;
using Shouldly;
using Listless;

public class ListlessTest : TestBehaviour
{
    List<int> it;
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
            .Then("no item should be chosen more than 25 percent of the time")
            .And("no item should be chosen less than 15 percent of the time")
            .Because("Random() should return fairly random results");

        Given("it contains numbers 1 through 5")
            .When("3 item are chosen")
            .Then("all 3 items should be contained in the list")
            .Because("Random(k) should return k items contained in the list");

        Given("it contains numbers 1 through 5")
            .When("3 items are chosen")
            .Then("none of the items should be duplicates")
            .Because("Random(k) should never return the same item twice");

        Given("it contains numbers 1 through 5")
            .When("3 random items are chosen 1000 times")
            .Then("no item should be chosen more than 25 percent of the time")
            .And("no item should be chosen less than 15 percent of the time")
            .Because("Random(k) should return fairly random results");

        Given("it contains numbers 1 through 5")
            .When("it is shuffled 1000 times")
            .Then("no item should be in a position more than 25 percent of the time")
            .And("no item should be in a position less than 15 percent of the time")
            .Because("shuffle should be pretty random");
    }

    public void ItContainsNumbers__Through__(int start, int finish)
    {
        it = new List<int>();

        for (int i = start; i <= finish; i++)
        {
            it.Add(i);
        }
    }

    public void Index__And__AreSwapped(int a, int b)
    {
        it.Swap(a, b);
    }

    public void Index__ShouldBe__(int index, int expected)
    {
        it[index].ShouldBe(expected);
    }
}
