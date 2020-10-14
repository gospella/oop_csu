import java.util.List;
import java.util.StringJoiner;

public class FamilyTree {
    public static void main(String[] args) {
        Person grandFather1 = new Person("Grandfather1", 80);
        Person grandMother1 = new Person("Grandmother1", 80);
        Person grandFather2 = new Person("Grandfather2", 80);
        Person grandMother2 = new Person("Grandmother2", 80);

        Person father = new Person("Father", 40, grandFather1, grandMother1);
        Person uncle = new Person("Uncle", 40,  grandFather1, grandMother1);

        Person mother = new Person("Mother",40, grandFather2, grandMother2);
        Person aunt = new Person("Aunt",40, grandFather2, grandMother2);

        father.setPartner(mother);
        mother.setPartner(father);

        Person child1 = new Person("Child1",20, father, mother);
        Person child2 = new Person("Child2",20, father,mother);

        printRelationsInfoAboutPerson(father);
    }

    public static void printRelationsInfoAboutPerson(Person person){
        StringBuilder sb = new StringBuilder();
        sb.append(String.format("Person's name: %s\n", person.getName()));
        sb.append(String.format("Person's parents: %s\n",
                getStringSequenceFromList(person.getParents())));
        sb.append(String.format("Person's siblings: %s\n",
                getStringSequenceFromList(person.getSiblings())));
        sb.append(String.format("Person's Uncles and aunts: %s\n",
                getStringSequenceFromList(person.getUnclesAndAunts())));
        sb.append(String.format("Person's cousins: %s\n",
                getStringSequenceFromList(person.getCousins())));
        sb.append(String.format("Person's in-laws: %s\n\n",
                getStringSequenceFromList(person.getInLaws())));
        System.out.println(sb);
    }

    public static String getStringSequenceFromList(List<Person> personList){
        StringJoiner joiner = new StringJoiner(", ");
        if(personList.size() == 0) return "No relatives";
        for (Person person : personList) {
            joiner.add(person.getName());
        }
        return joiner.toString();
    }

}
