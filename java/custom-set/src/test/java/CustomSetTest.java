
import java.util.Arrays;
import java.util.Collections;
import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertNotNull;
import static org.junit.Assert.assertTrue;
import org.junit.Test;
// import org.junit.Ignore;

public class CustomSetTest {

    @Test
    public void setsWithNoElementsAreEmpty() {
        final boolean actual
                = new CustomSet<Integer>(Collections.emptyList())
                        .isEmpty();
        assertTrue(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void setsWithElementsAreNotEmpty() {
        final boolean actual
                = new CustomSet<Integer>(Arrays.asList(1))
                        .isEmpty();

        assertFalse(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void nothingIsContainedInAnEmptySet() {
        final boolean actual
                = new CustomSet<Integer>(Collections.emptyList())
                        .contains(1);

        assertFalse(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void whenTheElementIsInTheSet() {
        final boolean actual
                = new CustomSet<Integer>(Arrays.asList(1, 2, 3))
                        .contains(1);

        assertTrue(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void whenTheElementIsNotInTheSet() {
        final boolean actual
                = new CustomSet<Integer>(Arrays.asList(1, 2, 3))
                        .contains(4);

        assertFalse(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void emptySetIsASubsetOfAnotherEmptySet() {
        final boolean actual
                = new CustomSet<Integer>(Collections.emptyList())
                        .isSubset(
                                new CustomSet<Integer>(Collections.emptyList())
                        );

        assertTrue(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void emptySetIsASubsetOfNonEemptySet() {
        final boolean actual
                = new CustomSet<Integer>(Arrays.asList(1))
                        .isSubset(
                                new CustomSet<Integer>(Collections.emptyList())
                        );

        assertTrue(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void nonEmptySetIsNotASubsetOfEmptySet() {
        final boolean actual
                = new CustomSet<Integer>(Collections.emptyList())
                        .isSubset(
                                new CustomSet<Integer>(Arrays.asList(1))
                        );

        assertFalse(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void setIsASubsetOfSetWithExactSameElements() {
        final boolean actual
                = new CustomSet<Integer>(Arrays.asList(1, 2, 3))
                        .isSubset(
                                new CustomSet<Integer>(Arrays.asList(1, 2, 3))
                        );

        assertTrue(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void setIsASubsetOfLargerSetWithSameElements() {
        final boolean actual
                = new CustomSet<Integer>(Arrays.asList(4, 1, 2, 3))
                        .isSubset(
                                new CustomSet<Integer>(Arrays.asList(1, 2, 3))
                        );

        assertTrue(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void setIsNotASubsetOfSetThatDoesNotContainItsElements() {
        final boolean actual
                = new CustomSet<Integer>(Arrays.asList(4, 1, 3))
                        .isSubset(
                                new CustomSet<Integer>(Arrays.asList(1, 2, 3))
                        );

        assertFalse(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void theEmptySetIsDisjointWithItself() {
        final boolean actual
                = new CustomSet<Integer>(Collections.emptyList())
                        .isDisjoint(
                                new CustomSet<Integer>(Collections.emptyList())
                        );

        assertTrue(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void emptySetIsDisjointWithNonEmptySet() {
        final boolean actual
                = new CustomSet<Integer>(Collections.emptyList())
                        .isDisjoint(
                                new CustomSet<Integer>(Arrays.asList(1))
                        );

        assertTrue(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void nonEmptySetIsDisjointWithEmptySet() {
        final boolean actual
                = new CustomSet<Integer>(Arrays.asList(1))
                        .isDisjoint(
                                new CustomSet<Integer>(Collections.emptyList())
                        );

        assertTrue(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void setsAreNotDisjointIfTheyShareAnElement() {
        final boolean actual
                = new CustomSet<Integer>(Arrays.asList(1, 2))
                        .isDisjoint(
                                new CustomSet<Integer>(Arrays.asList(2, 3))
                        );

        assertFalse(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void setsAreDisjointIfTheyShareNoElements() {
        final boolean actual
                = new CustomSet<Integer>(Arrays.asList(1, 2))
                        .isDisjoint(
                                new CustomSet<Integer>(Arrays.asList(3, 4))
                        );

        assertTrue(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void emptySetsAreEqual() {
        final boolean actual
                = new CustomSet<Integer>(Collections.emptyList())
                        .equals(
                                new CustomSet<Integer>(Collections.emptyList())
                        );

        assertTrue(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void emptySetIsNotEqualToNonEmptySet() {
        final boolean actual
                = new CustomSet<Integer>(Collections.emptyList())
                        .equals(
                                new CustomSet<Integer>(Arrays.asList(1, 2, 3))
                        );

        assertFalse(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void nonEmptySetIsNotEqualToEmptySet() {
        final boolean actual
                = new CustomSet<Integer>(Arrays.asList(1, 2, 3))
                        .equals(
                                new CustomSet<Integer>(Collections.emptyList())
                        );

        assertFalse(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void setsWithTheSameElementsAreEqual() {
        final boolean actual
                = new CustomSet<Integer>(Arrays.asList(1, 2))
                        .equals(
                                new CustomSet<Integer>(Arrays.asList(2, 1))
                        );

        assertTrue(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void setsWithDifferentElementsAreNotEqual() {
        final boolean actual
                = new CustomSet<Integer>(Arrays.asList(1, 2, 3))
                        .equals(
                                new CustomSet<Integer>(Arrays.asList(1, 2, 4))
                        );

        assertFalse(actual);
    }

    @Test
    // @Ignore("Remove to run test")
    public void addToEmptySet() {
        final int element = 3;
        final CustomSet<Integer> expected
                = new CustomSet<Integer>(
                        Collections.unmodifiableList(Arrays.asList(element))
                );
        final CustomSet<Integer> actual
                = new CustomSet<Integer>(Collections.emptyList());

        actual.add(element);

        assertNotNull(actual);
        assertFalse(actual.isEmpty());
        assertTrue(expected.equals(actual));
    }

    @Test
    // @Ignore("Remove to run test")
    public void addToNonEmptySet() {
        final int element = 3;
        final CustomSet<Integer> expected
                = new CustomSet<Integer>(
                        Collections.unmodifiableList(Arrays.asList(1, 2, 3, 4))
                );
        final CustomSet<Integer> actual
                = new CustomSet<Integer>(Arrays.asList(1, 2, 4));

        actual.add(element);

        assertNotNull(actual);
        assertFalse(actual.isEmpty());
        assertTrue(expected.equals(actual));
    }

    @Test
    // @Ignore("Remove to run test")
    public void addingAnExistingElementDoesNotChangeTheSet() {
        final int element = 3;
        final CustomSet<Integer> expected
                = new CustomSet<Integer>(
                        Collections.unmodifiableList(Arrays.asList(1, 2, 3))
                );
        final CustomSet<Integer> actual
                = new CustomSet<Integer>(Arrays.asList(1, 2, 3));

        actual.add(element);

        assertNotNull(actual);
        assertTrue(expected.equals(actual));
    }

    @Test
    // @Ignore("Remove to run test")
    public void intersectionOfTwoEmptySetsIsAnEmptySet() {
        final CustomSet<Integer> actual
                = new CustomSet<Integer>(Collections.emptyList())
                        .getIntersection(
                                new CustomSet<Integer>(Collections.emptyList())
                        );

        assertNotNull(actual);
        assertTrue(actual.isEmpty());
    }

    @Test
    // @Ignore("Remove to run test")
    public void intersectionOfAnEmptySetAndNonEmptySetIsAnEmptySet() {
        final CustomSet<Integer> actual
                = new CustomSet<Integer>(Collections.emptyList())
                        .getIntersection(
                                new CustomSet<Integer>(Arrays.asList(3, 2, 5))
                        );

        assertNotNull(actual);
        assertTrue(actual.isEmpty());
    }

    @Test
    // @Ignore("Remove to run test")
    public void intersectionOfANonEmptySetAndAnEmptySetIsAnEmptySet() {
        final CustomSet<Integer> actual
                = new CustomSet<Integer>(Arrays.asList(1, 2, 3, 4))
                        .getIntersection(
                                new CustomSet<Integer>(Collections.emptyList())
                        );

        assertNotNull(actual);
        assertTrue(actual.isEmpty());

    }

    @Test
    // @Ignore("Remove to run test")
    public void intersectionOfTwoSetsWithNoSharedElementsIsAnEmptySet() {
        final CustomSet<Integer> actual
                = new CustomSet<Integer>(Arrays.asList(1, 2, 3))
                        .getIntersection(
                                new CustomSet<Integer>(Arrays.asList(4, 5, 6))
                        );

        assertNotNull(actual);
        assertTrue(actual.isEmpty());
    }

    @Test
    // @Ignore("Remove to run test")
    public void intersectionOfTwoSetsWithSharedElementsIsASetOfTheSharedElements() {
        final CustomSet<Integer> expected
                = new CustomSet<Integer>(
                        Collections.unmodifiableList(Arrays.asList(2, 3))
                );
        final CustomSet<Integer> actual
                = new CustomSet<Integer>(Arrays.asList(1, 2, 3, 4))
                        .getIntersection(
                                new CustomSet<Integer>(Arrays.asList(3, 2, 5))
                        );

        assertNotNull(actual);
        assertFalse(actual.isEmpty());
        assertTrue(expected.equals(actual));
    }

    @Test
    // @Ignore("Remove to run test")
    public void differenceOfTwoEmptySetsIsAnEmptySet() {
        final CustomSet<Integer> actual
                = new CustomSet<Integer>(Collections.emptyList())
                        .getDifference(
                                new CustomSet<Integer>(Collections.emptyList())
                        );

        assertNotNull(actual);
        assertTrue(actual.isEmpty());
    }

    @Test
    // @Ignore("Remove to run test")
    public void differenceOfAnEmptySetAndNonEmptySetIsAnEmptySet() {
        final CustomSet<Integer> actual
                = new CustomSet<Integer>(Collections.emptyList())
                        .getDifference(
                                new CustomSet<Integer>(Arrays.asList(3, 2, 5))
                        );

        assertNotNull(actual);
        assertTrue(actual.isEmpty());
    }

    @Test
    // @Ignore("Remove to run test")
    public void differenceOfANonEmptySetAndAnEmptySetIsTheNonEmptySet() {
        final CustomSet<Integer> expected
                = new CustomSet<Integer>(
                        Collections.unmodifiableList(Arrays.asList(1, 2, 3, 4))
                );
        final CustomSet<Integer> actual
                = new CustomSet<Integer>(Arrays.asList(1, 2, 3, 4))
                        .getDifference(
                                new CustomSet<Integer>(Collections.emptyList())
                        );

        assertNotNull(actual);
        assertFalse(actual.isEmpty());
        assertTrue(expected.equals(actual));
    }

    @Test
    // @Ignore("Remove to run test")
    public void differenceOfTwoNonEmptySetsIsASetOfElementsThatAreOnlyInTheFirstSet() {
        final CustomSet<Integer> expected
                = new CustomSet<Integer>(
                        Collections.unmodifiableList(Arrays.asList(1, 3))
                );
        final CustomSet<Integer> actual
                = new CustomSet<Integer>(Arrays.asList(3, 2, 1))
                        .getDifference(
                                new CustomSet<Integer>(Arrays.asList(2, 4))
                        );

        assertNotNull(actual);
        assertFalse(actual.isEmpty());
        assertTrue(expected.equals(actual));
    }

    @Test
    // @Ignore("Remove to run test")
    public void unionOfTwoEmptySetsIsAnEmptySet() {
        final CustomSet<Integer> actual
                = new CustomSet<Integer>(Collections.emptyList())
                        .getUnion(
                                new CustomSet<Integer>(Collections.emptyList())
                        );

        assertNotNull(actual);
        assertTrue(actual.isEmpty());
    }

    @Test
    // @Ignore("Remove to run test")
    public void unionOfAnEmptySetAndNonEmptySetIsTheNonEmptySet() {
        final CustomSet<Integer> expected
                = new CustomSet<Integer>(
                        Collections.unmodifiableList(Arrays.asList(2))
                );
        final CustomSet<Integer> actual
                = new CustomSet<Integer>(Collections.emptyList())
                        .getUnion(
                                new CustomSet<Integer>(Arrays.asList(2))
                        );

        assertNotNull(actual);
        assertFalse(actual.isEmpty());
        assertTrue(expected.equals(actual));
    }

    @Test
    // @Ignore("Remove to run test")
    public void unionOfANonEmptySetAndAnEmptySetIsTheNonEmptySet() {
        final CustomSet<Integer> expected
                = new CustomSet<Integer>(
                        Collections.unmodifiableList(Arrays.asList(1, 3))
                );
        final CustomSet<Integer> actual
                = new CustomSet<Integer>(Arrays.asList(1, 3))
                        .getUnion(
                                new CustomSet<Integer>(Collections.emptyList())
                        );

        assertNotNull(actual);
        assertFalse(actual.isEmpty());
        assertTrue(expected.equals(actual));
    }

    @Test
    // @Ignore("Remove to run test")
    public void unionOfTwoNonEmptySetsContainsAllUniqueElements() {
        final CustomSet<Integer> expected
                = new CustomSet<Integer>(
                        Collections.unmodifiableList(Arrays.asList(3, 2, 1))
                );
        final CustomSet<Integer> actual
                = new CustomSet<Integer>(Arrays.asList(1, 3))
                        .getUnion(
                                new CustomSet<Integer>(Arrays.asList(2, 3))
                        );

        assertNotNull(actual);
        assertFalse(actual.isEmpty());
        assertTrue(expected.equals(actual));
    }

}
