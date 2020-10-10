import java.util.ArrayList;
import java.util.List;

public class Person {
    private String name;
    private Person mother;
    private Person father;

    private Person partner;
    private List<Person> children = new ArrayList<>();

    public Person(String name) {
        this.name = name;
    }

    public Person(String name, Person father, Person mother) {
        this(name);
        this.father = father;
        this.mother = mother;
        father.addChild(this);
        mother.addChild(this);
    }

    public Person(String name, Person father, Person mother, Person partner) {
        this(name, father, mother);
        this.partner = partner;
    }

    public String getName() {
        return name;
    }

    public void setPartner(Person partner) {
        if(father != partner && mother != partner && !children.contains(partner)){
            this.partner = partner;
        }
    }

    public void addChild(Person child){
        if(father != child && mother != child && partner != child){
            children.add(child);
        }
    }

    public List<Person> getParents(){
        List<Person> parents = new ArrayList<>();
        if(mother != null) parents.add(mother);
        if(father != null) parents.add(father);
        return parents;
    }

    public List<Person> getSiblings(){
        List<Person> siblings = new ArrayList<>();
        if(mother != null){
            siblings.addAll(mother.children);
        } else if(father != null){
            siblings.addAll(father.children);
        }
        if(siblings.contains(this)) siblings.remove(this);
        return siblings;
    }

    public List<Person> getUnclesAndAunts(){
        List<Person> unclesAndAunts = new ArrayList<>();
        if(mother != null) {
            for (Person person:
                    mother.getSiblings()) {
                    unclesAndAunts.add(person);
                    if(person.partner != null) unclesAndAunts.add(person.partner);
            }
        }
        if(father != null) {
            for (Person person:
                    father.getSiblings()) {
                unclesAndAunts.add(person);
                if(person.partner != null) unclesAndAunts.add(person.partner);
            }
        }
        return unclesAndAunts;
    }

    public List<Person> getCousins(){
        List<Person> cousins = new ArrayList<>();
        for (Person uncleOrAunt:
             getUnclesAndAunts()) {
            cousins.addAll(uncleOrAunt.children);
        }
        return cousins;
    }

    public List<Person> getInLaws(){
        List<Person> inLaws = new ArrayList<>();
        if(partner == null) return inLaws;
        inLaws.addAll(partner.getParents());
        return inLaws;
    }
}
