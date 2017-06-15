import java.util.List;

final class RelationshipComputer<T> {
    public Relationship computeRelationship(List<T> a, List<T> b) {
        if (a.size() > b.size())  {
            if (computeRelationship(b, a) == Relationship.SUBLIST)
                return Relationship.SUPERLIST;
        }
        else {
            int limit = b.size() - a.size() + 1;
            for (int i = 0; i < limit; i++) {
                int j;
                for (j = 0; j < a.size() && a.get(j).equals(b.get(i + j)); j++);
                if (j == a.size())
                    return limit == 1 ? Relationship.EQUAL : Relationship.SUBLIST;
            }
        }
        return Relationship.UNEQUAL;
    }
}
