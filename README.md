Listless
========

Here's some extension methods I wish c# lists had.

Written for unity, sorry. x___x

List of Extension Methods
-------------------------

### list.Swap(a, b)
`var temp = oh god pls die;`

### list.Shuffle
Fisher-Yates shuffle

### list.Random()
Returns a random element from the list

### list.Random(count)
Returns `count` unique random elements from the list.

Throws `IndexOutOfRangeException` if you try to pull more items than exist in the list.

### list.RandomWithReplacement(count)
Returns `count` non-unique random elements from the list.

Does not throw errors EVER.
