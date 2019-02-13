using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotTakeGenerator : MonoBehaviour
{

    IList<List<TakeSubject>> takeTypeList;
    IList<TakeSubject> takeMiddles;

    static int[] categoryValues = new int[12];

    enum subject { person = 0, place, things, histEvent, singThing, entity };
    enum takeType { personPerson = 0, personPlace, personGroups, personThings, personEvent, personSingThing, personEntity,
        placePerson, placeGroups, placeThings, placePlace, placeEvent, placeSingThing, placeEntity, thingsPerson,
        thingsPlace, thingsThings, thingsGroup, thingsSingThing, thingsEntity, thingsEvent, groupsPerson,
        groupsPlace, groupsThings, groupsGroups, groupsEvent, groupsSingThing, groupsEntity,
        eventPerson, eventPlace, eventThings, eventGroups, eventEvent, eventSingThing, eventEntity,
        singThingPerson, singThingPlace, singThingThings, singThingGroups, singThingEvent, singThingSingThing,
        singThingEntity, entityPerson, entityPlace, entityThings, entityGroups, entityEvent, entitySingThing,
        entityEntity }
    enum category { DCCsecond = 0, DCCthird, DCCfaculty, DCC, UMD, UMDFaculty, physics, CS, academics, music, sports, engineering, informalGroup }

    
    private TakeMiddleRange personPersonRange = new TakeMiddleRange();
    private TakeMiddleRange personPlaceRange = new TakeMiddleRange();
    private TakeMiddleRange personGroupsRange = new TakeMiddleRange();
    private TakeMiddleRange personThingsRange = new TakeMiddleRange();
    private TakeMiddleRange personEventRange = new TakeMiddleRange();
    private TakeMiddleRange personSingThingRange = new TakeMiddleRange();
    private TakeMiddleRange personEntityRange = new TakeMiddleRange();
    private TakeMiddleRange placePersonRange = new TakeMiddleRange();
    private TakeMiddleRange placeGroupsRange = new TakeMiddleRange();
    private TakeMiddleRange placeThingsRange = new TakeMiddleRange();
    private TakeMiddleRange placeEventRange = new TakeMiddleRange();
    private TakeMiddleRange placePlaceRange = new TakeMiddleRange();
    private TakeMiddleRange placeSingThingRange = new TakeMiddleRange();
    private TakeMiddleRange placeEntityRange = new TakeMiddleRange();
 //   private TakeMiddleRange thingsPersonRange = new TakeMiddleRange();
 //   private TakeMiddleRange thingsPlaceRange = new TakeMiddleRange();
    private TakeMiddleRange thingsThingsRange = new TakeMiddleRange();
 //   private TakeMiddleRange thingsGroupRange = new TakeMiddleRange();
 //   private TakeMiddleRange thingsSingThingRange = new TakeMiddleRange();
 //   private TakeMiddleRange thingsEntityRange = new TakeMiddleRange();
 //   private TakeMiddleRange thingsEventRange = new TakeMiddleRange();
 //   private TakeMiddleRange groupsPersonRange = new TakeMiddleRange();
 //   private TakeMiddleRange groupsPlaceRange = new TakeMiddleRange();
 //   private TakeMiddleRange groupsThingsRange = new TakeMiddleRange();
    private TakeMiddleRange groupsGroupsRange = new TakeMiddleRange();
 //   private TakeMiddleRange groupsEventRange = new TakeMiddleRange();
 //   private TakeMiddleRange groupsSingThingRange = new TakeMiddleRange();
 //   private TakeMiddleRange groupsEntityRange = new TakeMiddleRange();
    private TakeMiddleRange eventPersonRange = new TakeMiddleRange();
 //   private TakeMiddleRange eventPlaceRange = new TakeMiddleRange();
 //   private TakeMiddleRange eventThingsRange = new TakeMiddleRange();
    private TakeMiddleRange eventGroupsRange = new TakeMiddleRange();
    private TakeMiddleRange eventEventRange = new TakeMiddleRange();
    private TakeMiddleRange eventSingThingRange = new TakeMiddleRange();
    private TakeMiddleRange eventEntityRange = new TakeMiddleRange();
//    private TakeMiddleRange singThingPersonRange = new TakeMiddleRange();
    private TakeMiddleRange singThingPlaceRange = new TakeMiddleRange();
    private TakeMiddleRange singThingThingsRange = new TakeMiddleRange();
    private TakeMiddleRange singThingGroupsRange = new TakeMiddleRange();
 //   private TakeMiddleRange singThingEventRange = new TakeMiddleRange();
    private TakeMiddleRange singThingSingThingRange = new TakeMiddleRange();
    private TakeMiddleRange singThingEntityRange = new TakeMiddleRange();
 //   private TakeMiddleRange entityPersonRange = new TakeMiddleRange();
 //   private TakeMiddleRange entityPlaceRange = new TakeMiddleRange();
 //   private TakeMiddleRange entityThingsRange = new TakeMiddleRange();
 //   private TakeMiddleRange entityGroupsRange = new TakeMiddleRange();
//    private TakeMiddleRange entityEventRange = new TakeMiddleRange();
//    private TakeMiddleRange entitySingThingRange = new TakeMiddleRange();
    private TakeMiddleRange entityEntityRange = new TakeMiddleRange();


    public class TakeSubject
    {
        private string name;
        private List<int> categories;

        public TakeSubject(string name, List<int> categories)
        {
            this.name = name;
            this.categories = categories;
        }

        public string GetName()
        {
            return name;
        }

        public List<int> GetCategories()
        {
            return categories;
        }
    }

    public class TakeMiddleRange
    {
        private int first = -1;
        private int last = -1;

        public TakeMiddleRange()
        {
            
        }

        public void SetFirst(int index)
        {
            first = index;
        }

        public void SetLast(int index)
        {
            last = index;
        }

        public int GetFirstIndex()
        {
            return first;
        }

        public int GetLastIndex()
        {
            return last;
        }
    }

    public class HotTake
    {
        private string text;
        private int value;

        public HotTake(string text, int value)
        {
            this.text = text;
            this.value = value;
        }

        public string GetText()
        {
            return text;
        }

        public int GetValue()
        {
            return value;
        }
    }

    public void Start()
    {
        takeTypeList = new List<List<TakeSubject>>();
        takeMiddles = new List<TakeSubject>();
        for (int i = 0; i < 6; i++)
        {
            takeTypeList.Add(new List<TakeSubject>());
        }

        { 
        // People:
        takeTypeList[(int)subject.person].Add(new TakeSubject("Nate Rogers", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.music, (int)category.CS, (int)category.physics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Tom Zong", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Tim Henderson", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.CS, (int)category.engineering, (int)category.music }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Anders Julin", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.music, (int)category.sports }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("AJ Shannon", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.engineering, (int)category.sports }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Jordan Woo", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.DCCthird, (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Jesse Parreira", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.engineering }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("John Ball", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.UMDFaculty, (int)category.physics, (int)category.CS, (int)category.music }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Matt Vorsteg", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.music, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Matt Graber", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.UMDFaculty, (int)category.music, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Omer Bowman", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.engineering }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Fred Delawie", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.DCCthird, (int)category.UMD, (int)category.engineering }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("James Hall", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.engineering }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Richard Ojo", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.CS, (int)category.engineering }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Quinn Morris", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.CS, (int)category.music }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Melissa Baum", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Emma Mirizio", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.physics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Emily Whittaker", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.music, (int)category.physics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Beth Sapitowicz", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Joy London", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Jasmine Lim", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Jessica Liu", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Allison Seo", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Anthony Jones", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.engineering }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Calvin Crunkleton", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Ngouyin Yip", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Chadeya Miller", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.DCCthird, (int)category.UMD, (int)category.CS, (int)category.engineering }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Amanda O'Shaughnessy", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.engineering, (int)category.sports }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Naomi Pomrenke", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Natalia Stepanova", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Proma Rahman", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.DCCthird, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Rhonda Traub", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Flo Ning", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.DCCthird, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("June Xu", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.DCCthird, (int)category.UMD, (int)category.UMDFaculty, (int)category.CS, (int)category.engineering }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Allison Lu", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD, (int)category.sports }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Amelia Cherian", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Amina Lampkin", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Aleah Green", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Lauren Frost", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Anna Mazzanti", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD, (int)category.CS, (int)category.engineering }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Anusha Dixit", new List<int> { (int)category.DCCthird, (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.engineering }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Ben Bond", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Bert Love", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD, (int)category.music, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Bryanna Nketia", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Cameron Moye", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD, (int)category.physics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Divya Gupta", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD, (int)category.engineering, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Ellie Litwack", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Emily Sann", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD, (int)category.physics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Felix Adams", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Jackson Devadas", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("James Biggins", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD, (int)category.CS, (int)category.sports }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Jayson DeNovellis", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Jonny Mack", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Josh Chen", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Kendall Price", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD, (int)category.CS, (int)category.engineering }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Kira Loshin", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Lauren Murphy", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Natasha Kodgi", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Nina Agrawal", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Lauren Murphy", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Owen Roy", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Rezi Greaves", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.DCCsecond, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Tiffany Tran", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Zander Forsythe", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Tyla Holoman", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Austin Hwa", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Bebo Harraz", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Logan King", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Clara Tam", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Sam Tang", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Ethan Xu", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Michelle Lui", new List<int> { (int)category.DCCthird, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Jack Liang", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Jennifer Wang", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Leeza Moldavchuk", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.physics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Nicki Ferinde", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.CS, (int)category.engineering }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Varun Singhai", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Vivian Yeh", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Will Cox", new List<int> { (int)category.DCCsecond, (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Krista Cabellero", new List<int> { (int)category.DCCfaculty, (int)category.DCC, (int)category.UMD, (int)category.UMDFaculty }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Joseph Meyer", new List<int> { (int)category.DCCfaculty, (int)category.DCC, (int)category.UMD, (int)category.UMDFaculty }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("DB Bauer", new List<int> { (int)category.DCCfaculty, (int)category.DCC, (int)category.UMD, (int)category.UMDFaculty }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Evan Golub", new List<int> { (int)category.DCCfaculty, (int)category.DCC, (int)category.UMD, (int)category.UMDFaculty, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Porter Olsen", new List<int> { (int)category.DCCfaculty, (int)category.DCC, (int)category.UMD, (int)category.UMDFaculty, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Jarah Moesch", new List<int> { (int)category.DCCfaculty, (int)category.DCC, (int)category.UMD, (int)category.UMDFaculty }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Jason Farman", new List<int> { (int)category.DCCfaculty, (int)category.DCC, (int)category.UMD, (int)category.UMDFaculty }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Nina Cardillo", new List<int> { (int)category.DCCfaculty, (int)category.DCC, (int)category.DCCsecond, (int)category.UMD, (int)category.UMDFaculty }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Nina Dinh", new List<int> { (int)category.DCCfaculty, (int)category.DCC, (int)category.UMD, (int)category.UMDFaculty }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Michelle Butler", new List<int> { (int)category.DCCfaculty, (int)category.DCC, (int)category.UMD, (int)category.UMDFaculty, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Alexis Lothian", new List<int> { (int)category.DCCfaculty, (int)category.DCC, (int)category.UMD, (int)category.UMDFaculty, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Pedram Sadeghian", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Sahar Khamis", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCfaculty, (int)category.UMDFaculty, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Wallace Loh", new List<int> { (int)category.UMD, (int)category.UMDFaculty }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Coach DJ Durkin", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.sports }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Testudo", new List<int> { (int)category.UMD, (int)category.UMDFaculty }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Dr. Gregory Ball", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Roger Eastman", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Clyde Kruskal", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Jason Fillipou", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Dean Osmar Hebert", new List<int> { (int)category.UMD, (int)category.UMDFaculty }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Judy Tram", new List<int> { (int)category.UMD, (int)category.DCC }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Craig Potter", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.music }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Chris Gekker", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.music, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Brad Sanders", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Kendall Williams", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.engineering, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Tim Pilachowski", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor John Millson", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Raluca Rosca", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Humongous Anders", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.physics, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Jordan Goodman", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.physics, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Ian Applebaum", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.physics, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Big Anders", new List<int> { (int)category.UMD, (int)category.physics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Thicc Anders", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Miniscule Anders", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Emily Gong", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Ajeet Gary", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Vlad Dobrin", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Emily Golub", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Demitri Garbis", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Jonah Pool", new List<int> { (int)category.UMD, (int)category.physics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Matt Polvinale", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Lambros Syrmos", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Emily Dunham", new List<int> { (int)category.UMD, (int)category.CS, (int)category.engineering, (int)category.music }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Jack Iler", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Josh Wentling", new List<int> { (int)category.UMD, (int)category.CS, (int)category.engineering }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Maddie Bowcutt", new List<int> { (int)category.UMD, (int)category.DCCsecond, (int)category.UMDFaculty, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Bikeal", new List<int> { (int)category.UMD, (int)category.physics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Chris Cha", new List<int> { (int)category.UMD, (int)category.CS, (int)category.engineering }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("British Girl", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Kayla Jaffe", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Jack", new List<int> { (int)category.UMD, (int)category.engineering, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Vanilla Anders/Blanders", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Galen Stetsyuk (the Founder and CEO of MPLEX)", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Joshua Twitty", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Matthias Zwicker", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Independent Gary", new List<int>()));
        takeTypeList[(int)subject.person].Add(new TakeSubject("DJ Chris Styles", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("High-Five Guy", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Pan Flute Guy", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Tim from Tim's Tastings", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.UMD, (int)category.engineering }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Tom from Tom's Tastings", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Dr. Desmesmert", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Dr. Whittaker", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Beauregard Bowman", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.UMD, (int)category.sports }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Jim Bowman", new List<int> { (int)category.sports }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Tim O. Thee", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.UMD, (int)category.sports }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Timothy Hicks", new List<int> { (int)category.DCC, (int)category.DCCthird, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Colin Dunphy", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("JIM the Jazz Machine", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("MDale", new List<int> { (int)category.DCCsecond, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("The Ghost of Prince Frederick", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.UMD }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Mya Tsang", new List<int> { (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Kyle Hurley", new List<int> { (int)category.UMD, (int)category.music, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Julie Ren", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Professor Amitabh Varshney", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Ming Lin", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Spooky Matt", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Paulos Elias", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.person].Add(new TakeSubject("Earl Stone", new List<int> { (int)category.UMD, (int)category.academics }));


        // Place
        takeTypeList[(int)subject.place].Add(new TakeSubject("Prince Frederick Hall", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Second Floor of Prince Frederick Hall", new List<int> { (int)category.UMD, (int)category.DCCsecond }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("P. Freddy", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Second Floor social lounge", new List<int> { (int)category.UMD, (int)category.DCCsecond }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Third Floor social lounge", new List<int> { (int)category.UMD, (int)category.DCCthird }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Second Floor study lounge", new List<int> { (int)category.UMD, (int)category.DCCsecond, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Third Floor study lounge", new List<int> { (int)category.UMD, (int)category.DCCthird, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Xfinity Center", new List<int> { (int)category.UMD, (int)category.sports }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The South Campus Diner", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("McKeldin Mall", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("McKeldin Library", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Hornbake Library", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Iribe Center", new List<int> { (int)category.UMD, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Wicomico", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Oakland", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Elkton", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Denton", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Testudo Statue", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("CSIC", new List<int> { (int)category.UMD, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("A.V. Williams", new List<int> { (int)category.UMD, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Glenn L. Martin", new List<int> { (int)category.UMD, (int)category.engineering, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Glenn L. Martin Food Court", new List<int> { (int)category.UMD, (int)category.engineering }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("251 North", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Reckord Armory", new List<int> { (int)category.UMD, (int)category.academics, (int)category.sports }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The \"M\" Circle", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Lot 1", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Clarice Smith Performing Arts Center", new List<int> { (int)category.UMD, (int)category.music, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Kirwan Hall", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Capital One Field at Maryland Stadium", new List<int> { (int)category.UMD, (int)category.sports }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Stamp Student Union", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Frat Row", new List<int> { (int)category.UMD, (int)category.sports }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Meme Factory", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Ranch, brought to you by the bean factory", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("\"The Barn\"", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Physical Science Complex", new List<int> { (int)category.UMD, (int)category.academics, (int)category.physics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The hole in the PSC", new List<int> { (int)category.UMD, (int)category.physics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Point of Failure", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("South Campus Commons", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Adele's at Stamp", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Maryland Dairy", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The office where Nate's physics professor does not hold office hours", new List<int> { (int)category.UMD, (int)category.physics, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Architechure Building", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Mowatt Garage", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Caroline Hall", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("2218 Prince Frederick Hall", new List<int> { (int)category.UMD, (int)category.DCCsecond }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("2106 Prince Frederick Hall", new List<int> { (int)category.UMD, (int)category.DCCsecond }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Richie Colliseum", new List<int> { (int)category.UMD, (int)category.sports }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("2214 Prince Frederick Hall", new List<int> { (int)category.UMD, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("2235 Prince Frederick Hall", new List<int> { (int)category.UMD, (int)category.DCCsecond }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The DCC Lab", new List<int> { (int)category.UMD, (int)category.DCC }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Edward St. John Teaching and Learning Center", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The DCC sound studio", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.music }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("McKeldin Fountain", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Wood's Hall", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Jimenez Hall", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The WMUC radio station", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Diamondback Newsroom", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Campus Drive", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Preinkert Drive", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Anne Arundel Hall", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Eppely Recreation Center", new List<int> { (int)category.UMD, (int)category.sports }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Regents Drive", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Regents Drive Garage", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Seventh Floor of Prince Frederick", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Sixth Floor of Prince Frederick", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Fifth Floor of Prince Frederick", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Fourth Floor of Prince Frederick", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The elevator of A.V. Williams", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("CSIC 3117", new List<int> { (int)category.UMD, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The VR Lab", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Cole Field House", new List<int> { (int)category.UMD, (int)category.sports }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The UMD Health Center", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Kim Engineering Building", new List<int> { (int)category.UMD, (int)category.academics, (int)category.engineering }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Chemical and Nuclear Engineering Building", new List<int> { (int)category.UMD, (int)category.engineering, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Toll Physics Building", new List<int> { (int)category.UMD, (int)category.physics, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Washington Quad", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The North Campus Diner", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("South Campus", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("North Campus", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Route 1", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Milkboy Arthouse", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Chick-Fil-A", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Memorial Chapel", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Bob \"Turtle\" Smith Stadium at Shipley Field", new List<int> { (int)category.UMD, (int)category.sports }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The School of Public Health", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The playground outside LeFrak", new List<int> { (int)category.UMD, (int)category.sports }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("Tawes Hall", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Learning to Talk Lab", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Wyoming Farm", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("SCUB II", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The elevators of Prince Frederick Hall", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The front desk of Prince Frederick Hall", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The basement of Anne Arundel Hall", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The bridge between A.V. Williams and CSIC", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("The Book Lab in Tawes", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.place].Add(new TakeSubject("CDepot", new List<int> { (int)category.UMD, (int)category.music }));


        // Things and people (plural): Must check in predicate section whether it is a plural thing or people for sentence to make sense
        // (check if category.informalGroup, these are the groups of people)
        takeTypeList[(int)subject.things].Add(new TakeSubject("Dinstas", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("DCC Blog Posts", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("DCC Twitter Posts", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("DCC students", new List<int> { (int)category.UMD, (int)category.DCCsecond, (int)category.DCCthird, (int)category.DCC, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("DCC classes", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("HDCC105 Discussions", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Manifestos", new List<int> { (int)category.DCC }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Turtles", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Terrapins", new List<int> { (int)category.UMD, (int)category.sports }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Wallace Loh's Terrapin pins", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("DCC Design Camps", new List<int> { (int)category.UMD, (int)category.DCC }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("DCC lab hours", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Evan Golub's squirrel photos", new List<int> { (int)category.UMD, (int)category.DCC }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Squirrels", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Crabs", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("DCC faculty members", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCfaculty, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People who live on the second floor of Prince Frederick", new List<int> { (int)category.UMD, (int)category.DCCsecond, (int)category.DCC, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People who live on the third floor of Prince Frederick", new List<int> { (int)category.UMD, (int)category.DCCthird, (int)category.DCC, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Computer science majors", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Physics majors", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.physics, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Business majors", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Architecture majors", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Engineering majors", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.academics, (int)category.engineering }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("UMD Football players", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.sports }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("DCC alumni", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People in HDCC105", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.DCCthird, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("DCC Capstones", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People in University Honors", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People in XR Club", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.CS }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People who are in the XR Club leadership", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.CS }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("XR Club Members", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.CS }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People who are in Evan Golub's DCC class", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.DCCthird, (int)category.informalGroup, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People who are in Gemstone", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Diamondback Employees", new List<int> { (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The writers of Maryland Today", new List<int> { (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("WMUC radio shows", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The members of Hard Space Math", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.informalGroup, (int)category.music, (int)category.physics, (int)category.CS }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The members of Soft Earth Poets", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.informalGroup, (int)category.music, (int)category.physics, (int)category.CS }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The members of TMM", new List<int> { (int)category.UMD, (int)category.DCCsecond, (int)category.DCC, (int)category.informalGroup, (int)category.music, (int)category.CS, (int)category.engineering }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People who have WMUC radio shows", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.music }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Fans of Tim's Tastings", new List<int> { (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People in University Honors", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The random people in the background of Tim's Tastings episodes", new List<int> { (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The 37 followers of TMM on Spotify", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.music }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Jesse's Twitter accounts", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.UMD }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The members of DCC StuCo", new List<int> { (int)category.UMD, (int)category.DCCthird, (int)category.DCC, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The members of RHA", new List<int> { (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The North Hill RHA social media accounts", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The members of SGA", new List<int> { (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Professors", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("TAs", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Student Facilitators", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The Student Facilitators of CMSC389U", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.academics, (int)category.CS }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Good professors", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Bad professors", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.DCC, (int)category.DCCfaculty, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The variety of Anderses", new List<int> { (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People who drop DCC", new List<int> { (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People who are from out-of-state", new List<int> { (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People who are from in-state", new List<int> { (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People who don't like Old Bay", new List<int> { (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People who listen to Escape Velocity", new List<int> { (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Fans of TMM", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.music }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Fans of Hard Space Math", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.music }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Fans of Soft Earth Poets", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.music }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The squirrels of UMD", new List<int> { (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The framed photos in the basement of the Math building that are labeled in Comic Sans", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People who come to XR Club tutorials", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.CS }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Members of XR Club", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.CS }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People in CMSC131", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People who sign up for clubs at First Look Fair but never go to any meetings", new List<int> { (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People who donate cups to Jesse's cup stack", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.DCCthird, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The cups of Jesse's cup stack", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People who are condescending", new List<int> { (int)category.DCCthird, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("DCC projects", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The DCC t-shirt design contest submissions", new List<int> { (int)category.UMD, (int)category.DCC }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The residents of 2218", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Members of DCC Theta class", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.DCCthird, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Members of DCC Eta class", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.DCCthird, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Members of DCC Iota class", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.DCCthird, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The founders of DCC", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.DCCthird, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Frat boys", new List<int> { (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Sorority girls", new List<int> { (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("STEM majors", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.academics, (int)category.engineering, (int)category.CS }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Music majors", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.music }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("ACES kids", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.CS }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("DCC event bagels", new List<int> { (int)category.UMD, (int)category.DCC }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Tim's Tastings episodes", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("TMM songs", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Hard Space Math songs", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Soft Earth Poets songs", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Subscribers of Matt Vorsteg's YouTube channel", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Followers of Jesse's joke Twitter account", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("DCC couples", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.DCCthird, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Football games", new List<int> { (int)category.UMD, (int)category.sports }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Soccer games", new List<int> { (int)category.UMD, (int)category.sports }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Hard Space Math rehearsals", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Soft Earth Poets rehearsals", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People who are in DCC but don't live in Prince Frederick", new List<int> { (int)category.DCC, (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People who quit DCC", new List<int> { (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("People who rush frats", new List<int> { (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The brothers of Phi Mu Alpha", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.music }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Evan Golub's many cameras", new List<int> { (int)category.UMD, (int)category.DCC }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Jesse's custom Snapchat filters", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.CS }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("AJ's frat boys", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The monitors in the ACES lab", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Anders Julin's guitars", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Tim Henderson's harmonicas", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Matt Graber's harmonicas", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Tim and Anders avacado whiteboard drawings", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("AJ's rap lyrics he puts on his whiteboard", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Emma's hundreds of NASA stickers", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.physics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The bouncers at R.J. Bentley's", new List<int> { (int)category.UMD, (int)category.informalGroup }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("The Jazz Professors", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.music, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Public tests", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Secret Tests", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Release Tests", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Release Tokens", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Computer Engineering majors", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.CS, (int)category.engineering, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Aerospace Engineering majors", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.academics, (int)category.engineering }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Polymorphic Binary Search Trees", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Proofs by Weak Induction", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Proofs by Strong Induction", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Philosophy majors", new List<int> { (int)category.UMD, (int)category.informalGroup, (int)category.academics }));
        takeTypeList[(int)subject.things].Add(new TakeSubject("Jordan Woo's Unity tutorial demo projects", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCthird, (int)category.CS }));


        // historicalEvents:
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The day of the Poptart fire", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.UMD }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The filming of the Ghost of Prince Frederick", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.UMD }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The DCC design camp", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.UMD }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Move-in day", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.UMD }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The construction of the Iribe center", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.UMD, (int)category.engineering, (int)category.CS }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Nate's take-down of Bikeal", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.UMD }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("AJ asking Jesse, Omer, Fred, and James for help for the hundredth time", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.UMD, (int)category.engineering, (int)category.academics }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The football game", new List<int> { (int)category.UMD, (int)category.sports }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The day Calvin was asked to wear a shirt when in the social lounge", new List<int> { (int)category.DCC, (int)category.DCCsecond, (int)category.UMD }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The announcement of the construction of the Purple Line", new List<int> { (int)category.UMD, (int)category.engineering }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The Hard Space Math concert", new List<int> { (int)category.UMD, (int)category.DCCsecond, (int)category.DCC, (int)category.music }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The first TMM performance", new List<int> { (int)category.UMD, (int)category.DCCsecond, (int)category.DCC, (int)category.music }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The first Soft Earth Poets performance", new List<int> { (int)category.UMD, (int)category.DCCsecond, (int)category.DCC, (int)category.music }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The first Hard Space Math rehearsal", new List<int> { (int)category.UMD, (int)category.DCCsecond, (int)category.DCC, (int)category.music }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The last Hard Space Math rehearsal", new List<int> { (int)category.UMD, (int)category.DCCsecond, (int)category.DCC, (int)category.music }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The day John got trapped in the elevator at the PSC", new List<int> { (int)category.UMD, (int)category.DCCsecond, (int)category.physics }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("DCC in DC", new List<int> { (int)category.DCC, (int)category.UMD }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Bitcamp 2018", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The premier of the Ghost of Prince Frederick", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The filming of JIM the Jazz Machine", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.CS }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Ngyouyin finding a nail in his salad", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The filming of the first episode of Tim's Tastings", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The premier of the first episode of Tim's Tastings", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The creation of the Second Floor chess set", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.engineering }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Joining DCC", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.DCCthird }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Quitting DCC", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.DCCthird }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Calvin spamming \"2nd Floor Best Floor with\" bad memes", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Fall 2017 Paranoia", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Calvin killing John in Paranoia", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Nate killing Tim in Paranoia", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Nate betraying John in Paranoia", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Jesse betraying everyone in Paranoia", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Evan Golub's CMSC131 final exam", new List<int> { (int)category.UMD, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The blackjack project in CMSC132", new List<int> { (int)category.UMD, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The Eats and Beets festival at the South Campus Diner", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Joy and Jasmine's Fruit Fiesta", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Joy and Jasmine's Peach Party", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Joy and Jasmine's Holiday Party", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Mandatory Fun", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.sports }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The DCC flash mob", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.DCCthird, (int)category.music }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Posting dinstas", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.DCCthird, (int)category.academics }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Buying the record player", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Fred and Emily's big summer road trip", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Fred and Anders' big summer road trip", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Throwing pumpkins off Mowatt Garage", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Tim from Tim's Tastings having a heart attack at the South Campus Diner", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Tim from Tim's Tastings meeting Dr. Desmesmert for the first time", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The filming of the first Tom's Tastings episode", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Matt Vorsteg asking Judy Tram to the DCC dance", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The DCC dance", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The day classes were cancelled because it was too windy", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.academics }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The night Matt Vorsteg pregamed Baby Driver", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("High Five Guy being interviewed on Tim's Tastings", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("High Five Guy's last day", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Pan Flute Guy's performance on his last day", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Pan Flute Guy's last day", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Tim from Tim's Tastings being nominated for Meme of the Year", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Tim from Tim's Tastings losing Meme of the Year to Pan Flute Guy", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The creation of Second Floor Shenanigans", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.CS }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Tim, Matt, and Matt being out here in compsci", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Beth leaving \"2nd Floor Best Floor\"", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Elkton's residents being evacuated because of mold", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Mya Tsang showing up to the second floor out of the blue", new List<int> { (int)category.UMD, (int)category.DCCsecond, (int)category.CS }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The DCC StuCo elections", new List<int> { (int)category.UMD, (int)category.DCCthird, (int)category.DCCthird }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The DCC Big-Little tours", new List<int> { (int)category.UMD, (int)category.DCCthird, (int)category.DCCthird, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Moving James' couch into his room freshman year", new List<int> { (int)category.UMD, (int)category.DCCsecond, (int)category.DCC }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Moving James' couch into his room sophomore year", new List<int> { (int)category.UMD, (int)category.DCCsecond, (int)category.DCC }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Fred quitting DCC", new List<int> { (int)category.UMD, (int)category.DCCsecond, (int)category.DCC }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("AJ rushing a fraternity", new List<int> { (int)category.UMD, (int)category.DCCsecond, (int)category.DCC }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Matt Vorsteg rushing Phi Mu Alpha", new List<int> { (int)category.UMD, (int)category.DCCsecond, (int)category.DCC, (int)category.music }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Omer Bowman joining the XR Club as a mentor", new List<int> { (int)category.UMD, (int)category.DCCsecond, (int)category.DCC, (int)category.CS }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("AR club and VR club merging to form XR club", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The DCC capstone proposal writing worksop", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.academics }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Choosing a capstone for DCC", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.academics }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Calvin Crunkleton going to work out at the gym", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.sports }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Nate cutting his lucious locks", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("AJ getting a fade", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Hard Space Math recording \"Billy Faulkner\"", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Fred and Jordan moving up to third floor", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.DCCthird }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Flo and June moving down to second floor", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.DCCthird }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The founding of Hard Space Math", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The founding of Soft Earth Poets", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The founding of TMM", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The breakup of Hard Space Math", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Rolling up to 2218", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("Matt Vorsteg taking a nibble out of Nick de Grabda's plant", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("AJ asking the DCC Theta and Iota GroupMe for a sailor's hat", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The career fair", new List<int> { (int)category.UMD, (int)category.CS, (int)category.engineering, (int)category.academics }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("The computer science career fair", new List<int> { (int)category.UMD, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("CMSC 250", new List<int> { (int)category.UMD, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("CMSC 131", new List<int> { (int)category.UMD, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("CMSC 132", new List<int> { (int)category.UMD, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("CMSC 216", new List<int> { (int)category.UMD, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("ASTR 100", new List<int> { (int)category.UMD, (int)category.physics, (int)category.academics }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("ENES 101", new List<int> { (int)category.UMD, (int)category.engineering, (int)category.academics }));
        takeTypeList[(int)subject.histEvent].Add(new TakeSubject("HDCC 105", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.academics }));


        //Things (singular)
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("John's fancy red keyboard", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The DCC logo", new List<int> { (int)category.UMD, (int)category.DCC }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("@VeryNiceJokes, Jesse's joke Twitter account,", new List<int> { (int)category.UMD, (int)category.DCC }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The first peach that Matt Vorsteg ever gave to Jasmine", new List<int> { (int)category.UMD, (int)category.DCC }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("DCC", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.academics }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("ACES", new List<int> { (int)category.UMD, (int)category.academics, (int)category.CS }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The piano in Anne Arundel Hall", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The Poptart that Jesse burned", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The floor dinner", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Tim Henderson's guitar", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Matt Graber's guitar", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Anders Julin's guitar", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Calvin Crunkleton's oboe", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Fred's kite Eleanor", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.engineering }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The Testudo statue", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Jesse's Mamma Mia Snapchat filter", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.CS }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Joy's white mug", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Tim's Lockheed Martin water bottle", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.engineering }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Jordan's Lockheed Martin water bottle", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Nick de Grabda's plant", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("AJ's homework", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.engineering, (int)category.academics }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("AJ's frat", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("DCC homework", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.academics }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Tom Zong's capstone", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.academics }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Matt Vorsteg's bongos", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The microwave in the second floor lounge", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The record player in the second floor lounge", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Calvin Crunkleton's jean jacket", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The flat squirrel outside Prince Frederick", new List<int> { (int)category.UMD, (int)category.DCC }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Matt Graber's laptop", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.CS }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Jesse Parreira's Nintendo Switch", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Matt Vorsteg's Nintendo Switch", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Nicki's front porch", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("James Hall's onsie", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Fred's first DCC blog post", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.academics }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The 3D printer in the DCC lab", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.academics, (int)category.engineering }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Jennifer Wang's Student Judiciary application", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The DCC waterbottle", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Joseph Meyer's head", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Evan Golub's hat", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.CS }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Beth's sorority", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("AJ's laptop", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.engineering }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Jasmine's extra mattress", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Matt Vorsteg's whipped cream", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Tim's graded papers", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.academics, (int)category.engineering }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Joy's hairbun", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Anders' capo", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Anders' acoustic guitar", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Anders' fancy new electric guitar", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Anders' First Act electric guitar", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The printer in the DCC lab", new List<int> { (int)category.UMD, (int)category.DCC }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The \"Mapping the Overlooked\" assignment", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.academics }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Logan King's skateboard", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Evan Golub's CMSC131 class", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The CMSC132 blackjack project", new List<int> { (int)category.UMD, (int)category.academics, (int)category.CS }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The VR vibration chair in the XR lab in A.V. Williams", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The chair that Galen Stetsyuk (the Founder and CEO of MPLEX) sits in while in the XR lab", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Calvin's new glasses", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Ajeet Gary's tattoo of the Golden Ratio", new List<int> { (int)category.UMD, (int)category.UMDFaculty }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("John's hair", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("James' hair", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Nate's lost hair", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Fred's \"No Step On Snek\" flag", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCthird }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Nate's rainbow American flag", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Omer's keyboard", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Tim's keyboard", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("John's shakers", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Nate's theramin", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music, (int)category.engineering }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Quinn's cajon", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Quinn's drum pad", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("James and Richard's couch", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("James and Richard's projector", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("James and Richard's surround sound", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("James and Richard's dorm theater", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("James' popcorn-maker", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Matt Graber's diatonic harmonica", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Tim Henderson's big set of harmonicas", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Fred's \"Planes of UMD\" Instagram account", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The North Hill RHA Instagram account", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The North Hill RHA Twitter account", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The BSOS Instagram account", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Calvin's Wall of Inspiration", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Calvin and John's quote wall", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Calvin's missing shirt", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Matt Graber's trombone", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Nate Rogers' alto saxophone", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Nate Rogers' tenor saxophone", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Matt Vorsteg's trumpet", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The Tim's Tastings hat", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The Tim's Tastings red Maryland sweatshirt", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The Golden Spoon from Tim's Tastings", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The season 3 Tim's Tastings jacket", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The Tim's Tastings Season 1 intro", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The Tim's Tastings Season 2 intro", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The Tim's Tastings Season 3 intro", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Tim's Tastings Season 3", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Tim's Tastings Season 2", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Tim's Tastings Season 1", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The first episode of Tim's tastings", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Tom's Tastings", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Tim's Tastings", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The hot water faucet in the second floor social lounge", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The metaphorical disconnect between the second and third floors of Prince Frederick", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Nate's column in The Diamondback", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Second Floor Shenanigans", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.CS }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("\"Anders Makes It Rain\"", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.CS }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("\"Hot Takes with Nate Rogers\"", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.CS }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Professor Eastman's giraffe", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.CS }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Professor Eastman's CMSC250 lecture", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Professor Golub's CMSC131 lecture", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.DCCfaculty, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The legendary Panopto recording of Brad Sanders", new List<int> { (int)category.UMD, (int)category.UMDFaculty }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Jesse's sock drawings", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Jesse's cup stack", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("John's voice", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Nate's Diamondback salary", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Tim Henderson's TA class", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.engineering, (int)category.academics }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("John and Matt's HoloLens class", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Melissa Baum's big ruler", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Evan Golub's CD collection", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The Ghost of Prince Frederick", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("JIM the Jazz Machine", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Bongo Boi", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Professor Eastman's sense of humor", new List<int> { (int)category.UMD, (int)category.UMDFaculty, (int)category.CS }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("The Computer Science Submit Server", new List<int> { (int)category.UMD, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("ELMS", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.singThing].Add(new TakeSubject("Multi-factor Identification", new List<int> { (int)category.UMD, (int)category.CS }));

        // Entities:
        takeTypeList[(int)subject.entity].Add(new TakeSubject("DCC", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.academics }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("ACES", new List<int> { (int)category.UMD, (int)category.academics, (int)category.CS }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Honors Humanities", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("University Honors", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The Diamondback", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Maryland Today", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Gemstone", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("RHA", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("North Hill RHA", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Honors Student Programming Council", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("DCC StuCo", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCthird }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("UMD Dining Services", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("University Band", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("AJ's frat", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Beth's Sorority", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Phi Mu Alpha", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("University Wind Ensemble", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Jazz Lab", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The Computer Science Department", new List<int> { (int)category.UMD, (int)category.CS, (int)category.academics }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The Physics Department", new List<int> { (int)category.UMD, (int)category.academics, (int)category.physics }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The School of Behavioral and Social Sciences", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Robert H. Smith School of Business", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("TMM", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Hard Space Math", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Soft Earth Poets", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.music }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("DCC Theta class", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.DCCthird }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("DCC Eta class", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.DCCthird }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("DCC Iota class", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond, (int)category.DCCthird }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("XR Club", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("UMD SGA", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Second Floor Productions", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The Tastings Team", new List<int> { (int)category.UMD, (int)category.DCC, (int)category.DCCsecond }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The UMD football team", new List<int> { (int)category.UMD, (int)category.sports }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The UMD basketball team", new List<int> { (int)category.UMD, (int)category.sports }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The School of Architecture, Planning & Presevation", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The School of Theater, Dance, and Performance Studies", new List<int> { (int)category.UMD, (int)category.academics, (int)category.music }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("MPLEX", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("WMUC", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The UMD Administration", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Student Entertainment Events", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Terps After Dark", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("UMD Lettuce Club", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Terps Racing", new List<int> { (int)category.UMD, (int)category.engineering }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Terrapin Record Label", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The Astronomy Department", new List<int> { (int)category.UMD, (int)category.physics, (int)category.academics }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The A. James Clark School of Engineering", new List<int> { (int)category.UMD, (int)category.engineering, (int)category.academics }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The University of Maryland Marketing Department", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The Computer Engineering Department", new List<int> { (int)category.UMD, (int)category.academics, (int)category.CS }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The Phillip Merrill College of Journalism", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The UMD Department of Transportation", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Residence Life", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Green Terps", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Theta Tau", new List<int> { (int)category.UMD, (int)category.engineering }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The UMD Division of IT", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The Department of Counseling, Higher Education, and Special Education", new List<int> { (int)category.UMD, (int)category.academics }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The UMD class of 2021", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The UMD class of 2022", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("r/UMD", new List<int> { (int)category.UMD, (int)category.CS }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("UMD Mock Trial", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The marching band", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Cru", new List<int> { (int)category.UMD }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Engineers Without Borders", new List<int> { (int)category.UMD, (int)category.engineering }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Engineers With Borders", new List<int> { (int)category.UMD, (int)category.engineering }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("Gamer Symphony Orchestra", new List<int> { (int)category.UMD, (int)category.music }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The Quidditch team", new List<int> { (int)category.UMD, (int)category.sports }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("The soccer team", new List<int> { (int)category.UMD, (int)category.sports }));
        takeTypeList[(int)subject.entity].Add(new TakeSubject("MaryPIRG", new List<int> { (int)category.UMD }));
    }
        // Hot take middles!
        //personPerson
        takeMiddles.Add(new TakeSubject(" would be a better president than ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" has done more for the world than ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is a better baker than ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" would make for a better dinner date than ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" would probably work well romantically with ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is taller than ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is more economically responsible than ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" probably shouldn't go out with ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" would easily win in a cage fight against ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" owes most of life's success to ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" would be a good roommate for ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" would not be a good roommate for ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is a better friend than ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is more evil than ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is not quite as evil as ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" should be rewarded for helping ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" probably hates ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" probably is in love with ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" should style their hair after ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is always trying to replicate the wardrobe of ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" owes $20 to ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is secretly always looking for ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" has a better musical taste than ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" would like to indefinitely avoid seeing ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" should go for a walk with ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" needs to have a conversation with ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" should watch out for ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is a better person than ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is secretly the same person as ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is jealous of the hair of ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" needs to pay more attention to ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" should stop ignoring ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" should be ignoring ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is a better singer than ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is a better dancer than ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is more culturally competent than ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is a better at acting than ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" should start a talk show with ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" should move in with ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" needs to stay away from ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" can never escape ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" should meet ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" has never actually met ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" has never heard of ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" has been acting weird around ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is too good for ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" isn't good enough for ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" should not meet ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" really appreciates ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" spends too much time with ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" doesn't spend enough time with ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is more famous than ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" isn't as famous as ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is more competent than ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is a better teacher than ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is probably planning a party for ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is probably going to ask out ", new List<int> { (int)takeType.personPerson }));
        takeMiddles.Add(new TakeSubject(" is probably not going to ask out ", new List<int> { (int)takeType.personPerson }));


        takeMiddles.Add(new TakeSubject(" practically lives at ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" should move into ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" needs to stay away from ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" has always wanted to visit ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" should be the ruler of ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" can too often be found at ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject("'s favorite place is ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" loves eating at ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" takes too many pictures of ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" seems to always be hanging around ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" can never escape ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" can never leave ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" is never going to leave ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" should redesign ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" is too far from ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" really messed up ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" nearly destroyed ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" loves ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" hates ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" has never actually been to ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" generally tries to avoid ", new List<int> { (int)takeType.personPlace }));
        takeMiddles.Add(new TakeSubject(" is not allowed to visit ", new List<int> { (int)takeType.personPlace }));

        takeMiddles.Add(new TakeSubject(" is wanted by ", new List<int> { (int)takeType.personGroups }));
        takeMiddles.Add(new TakeSubject(" wants to join ", new List<int> { (int)takeType.personGroups }));
        takeMiddles.Add(new TakeSubject(" is better than ", new List<int> { (int)takeType.personGroups }));
        takeMiddles.Add(new TakeSubject(" should pay more attention to ", new List<int> { (int)takeType.personGroups }));
        takeMiddles.Add(new TakeSubject(" needs to avoid ", new List<int> { (int)takeType.personGroups }));
        takeMiddles.Add(new TakeSubject(" hates ", new List<int> { (int)takeType.personGroups }));
        takeMiddles.Add(new TakeSubject(" loves ", new List<int> { (int)takeType.personGroups }));
        takeMiddles.Add(new TakeSubject(" should be afraid of ", new List<int> { (int)takeType.personGroups }));
        takeMiddles.Add(new TakeSubject(" has an excessive love for ", new List<int> { (int)takeType.personGroups }));
        takeMiddles.Add(new TakeSubject(" should not be affiliated with ", new List<int> { (int)takeType.personGroups }));
        takeMiddles.Add(new TakeSubject(" never eats with ", new List<int> { (int)takeType.personGroups }));
        takeMiddles.Add(new TakeSubject(" has never seen ", new List<int> { (int)takeType.personGroups }));
        takeMiddles.Add(new TakeSubject(" has never heard of ", new List<int> { (int)takeType.personGroups }));
        takeMiddles.Add(new TakeSubject(" is not part of ", new List<int> { (int)takeType.personGroups }));
        takeMiddles.Add(new TakeSubject(" hates the sound of ", new List<int> { (int)takeType.personGroups }));
        takeMiddles.Add(new TakeSubject(" hates the smell of ", new List<int> { (int)takeType.personGroups }));
        takeMiddles.Add(new TakeSubject(" is afraid of ", new List<int> { (int)takeType.personGroups }));

        takeMiddles.Add(new TakeSubject(" feels passionate about ", new List<int> { (int)takeType.personThings }));
        takeMiddles.Add(new TakeSubject(" has a strange affinity for ", new List<int> { (int)takeType.personThings }));
        takeMiddles.Add(new TakeSubject(" really loves ", new List<int> { (int)takeType.personThings }));
        takeMiddles.Add(new TakeSubject(" hates ", new List<int> { (int)takeType.personThings }));
        takeMiddles.Add(new TakeSubject(" only wants ", new List<int> { (int)takeType.personThings }));
        takeMiddles.Add(new TakeSubject(" hates seeing ", new List<int> { (int)takeType.personThings }));
        takeMiddles.Add(new TakeSubject(" wants more ", new List<int> { (int)takeType.personThings }));
        takeMiddles.Add(new TakeSubject(" is a big fan of ", new List<int> { (int)takeType.personThings }));
        takeMiddles.Add(new TakeSubject(" appreciates ", new List<int> { (int)takeType.personThings }));

        takeMiddles.Add(new TakeSubject(" is afraid of ", new List<int> { (int)takeType.personSingThing }));
        takeMiddles.Add(new TakeSubject(" wants ", new List<int> { (int)takeType.personSingThing }));
        takeMiddles.Add(new TakeSubject(" is jealous of ", new List<int> { (int)takeType.personSingThing }));
        takeMiddles.Add(new TakeSubject(" hates ", new List<int> { (int)takeType.personSingThing }));
        takeMiddles.Add(new TakeSubject(" has never seen ", new List<int> { (int)takeType.personSingThing }));
        takeMiddles.Add(new TakeSubject(" is a big fan of ", new List<int> { (int)takeType.personSingThing }));
        takeMiddles.Add(new TakeSubject(" is not a big fan of ", new List<int> { (int)takeType.personSingThing }));
        takeMiddles.Add(new TakeSubject(" would love to lick ", new List<int> { (int)takeType.personSingThing }));

        takeMiddles.Add(new TakeSubject(" was a big fan of ", new List<int> { (int)takeType.personEvent }));
        takeMiddles.Add(new TakeSubject(" did not enjoy ", new List<int> { (int)takeType.personEvent }));
        takeMiddles.Add(new TakeSubject(" got way too litty during ", new List<int> { (int)takeType.personEvent }));
        takeMiddles.Add(new TakeSubject(" slept through most of ", new List<int> { (int)takeType.personEvent }));
        takeMiddles.Add(new TakeSubject(" enjoyed ", new List<int> { (int)takeType.personEvent }));
        takeMiddles.Add(new TakeSubject(" did not approve of ", new List<int> { (int)takeType.personEvent }));
        takeMiddles.Add(new TakeSubject(" witnessed ", new List<int> { (int)takeType.personEvent }));
        takeMiddles.Add(new TakeSubject(" was secretly watching ", new List<int> { (int)takeType.personEvent }));
        takeMiddles.Add(new TakeSubject(" came to ", new List<int> { (int)takeType.personEvent }));
        takeMiddles.Add(new TakeSubject(" was forever changed by ", new List<int> { (int)takeType.personEvent }));
        takeMiddles.Add(new TakeSubject(" was never the same after ", new List<int> { (int)takeType.personEvent }));

        takeMiddles.Add(new TakeSubject(" wants nothing to do with ", new List<int> { (int)takeType.personEntity }));
        takeMiddles.Add(new TakeSubject(" wants to join ", new List<int> { (int)takeType.personEntity }));
        takeMiddles.Add(new TakeSubject(" is wanted by ", new List<int> { (int)takeType.personEntity }));
        takeMiddles.Add(new TakeSubject(" is trying to uncover the dark secrets of ", new List<int> { (int)takeType.personEntity }));
        takeMiddles.Add(new TakeSubject(" is secretly a member of ", new List<int> { (int)takeType.personEntity }));
        takeMiddles.Add(new TakeSubject(" is part of ", new List<int> { (int)takeType.personEntity }));
        takeMiddles.Add(new TakeSubject(" is being hunted by ", new List<int> { (int)takeType.personEntity }));
        takeMiddles.Add(new TakeSubject(" is afraid of ", new List<int> { (int)takeType.personEntity }));
        takeMiddles.Add(new TakeSubject(" is considering joining ", new List<int> { (int)takeType.personEntity }));
        takeMiddles.Add(new TakeSubject(" doesn't approve of ", new List<int> { (int)takeType.personEntity }));
        takeMiddles.Add(new TakeSubject(" vehemently opposes ", new List<int> { (int)takeType.personEntity }));
        takeMiddles.Add(new TakeSubject(" is trying to improve ", new List<int> { (int)takeType.personEntity }));

        takeMiddles.Add(new TakeSubject(" is the permanent residence of ", new List<int> { (int)takeType.placePerson }));
        takeMiddles.Add(new TakeSubject(" is frequented by ", new List<int> { (int)takeType.placePerson }));
        takeMiddles.Add(new TakeSubject(" is the favorite location of ", new List<int> { (int)takeType.placePerson }));
        takeMiddles.Add(new TakeSubject(" is most often visited by ", new List<int> { (int)takeType.placePerson }));
        takeMiddles.Add(new TakeSubject(" is probably the birthplace of ", new List<int> { (int)takeType.placePerson }));
        takeMiddles.Add(new TakeSubject(" has never been visited by ", new List<int> { (int)takeType.placePerson }));
        takeMiddles.Add(new TakeSubject(" deserves to be visited by ", new List<int> { (int)takeType.placePerson }));

        takeMiddles.Add(new TakeSubject(" directly inspired ", new List<int> { (int)takeType.placePlace }));
        takeMiddles.Add(new TakeSubject(" is better than ", new List<int> { (int)takeType.placePlace }));
        takeMiddles.Add(new TakeSubject(" is a better study location than ", new List<int> { (int)takeType.placePlace }));
        takeMiddles.Add(new TakeSubject(" should be modelled after ", new List<int> { (int)takeType.placePlace }));
        takeMiddles.Add(new TakeSubject(" is a more appropriate location for a dance party than ", new List<int> { (int)takeType.placePlace }));
        takeMiddles.Add(new TakeSubject(" is more popular than ", new List<int> { (int)takeType.placePlace }));
        takeMiddles.Add(new TakeSubject(" is always more crowded than ", new List<int> { (int)takeType.placePlace }));
        takeMiddles.Add(new TakeSubject(" is more relevant than ", new List<int> { (int)takeType.placePlace }));
        takeMiddles.Add(new TakeSubject(" has essentially been replaced by ", new List<int> { (int)takeType.placePlace }));

        takeMiddles.Add(new TakeSubject(" has a lot of ", new List<int> { (int)takeType.placeThings }));
        takeMiddles.Add(new TakeSubject(" is filled with ", new List<int> { (int)takeType.placeThings }));
        takeMiddles.Add(new TakeSubject(" doesn't have any of ", new List<int> { (int)takeType.placeThings }));
        takeMiddles.Add(new TakeSubject(" does not allow ", new List<int> { (int)takeType.placeThings }));
        takeMiddles.Add(new TakeSubject(" will never allow ", new List<int> { (int)takeType.placeThings }));
        takeMiddles.Add(new TakeSubject(" will someday allow ", new List<int> { (int)takeType.placeThings }));
        takeMiddles.Add(new TakeSubject(" might have ", new List<int> { (int)takeType.placeThings }));

        takeMiddles.Add(new TakeSubject(" is filled with ", new List<int> { (int)takeType.placeGroups }));
        takeMiddles.Add(new TakeSubject(" has a lot of ", new List<int> { (int)takeType.placeGroups }));
        takeMiddles.Add(new TakeSubject(" doesn't have any of ", new List<int> { (int)takeType.placeGroups }));
        takeMiddles.Add(new TakeSubject(" is frequented by ", new List<int> { (int)takeType.placeGroups }));
        takeMiddles.Add(new TakeSubject(" is the favorite hang-out spot of ", new List<int> { (int)takeType.placeGroups }));
        takeMiddles.Add(new TakeSubject(" has never been visited by ", new List<int> { (int)takeType.placeGroups }));
        takeMiddles.Add(new TakeSubject(" was originally made for ", new List<int> { (int)takeType.placeGroups }));
        takeMiddles.Add(new TakeSubject(" does not allow ", new List<int> { (int)takeType.placeGroups }));

        takeMiddles.Add(new TakeSubject(" does not allow ", new List<int> { (int)takeType.placeSingThing }));
        takeMiddles.Add(new TakeSubject(" was once the location of ", new List<int> { (int)takeType.placeSingThing }));
        takeMiddles.Add(new TakeSubject(" once contained ", new List<int> { (int)takeType.placeSingThing }));
        takeMiddles.Add(new TakeSubject(" has never contained ", new List<int> { (int)takeType.placeSingThing }));
        takeMiddles.Add(new TakeSubject(" might have ", new List<int> { (int)takeType.placeSingThing }));
        takeMiddles.Add(new TakeSubject(" will never allow ", new List<int> { (int)takeType.placeSingThing }));
        takeMiddles.Add(new TakeSubject(" will someday allow ", new List<int> { (int)takeType.placeSingThing }));

        takeMiddles.Add(new TakeSubject(" is required for entry into ", new List<int> { (int)takeType.singThingPlace }));
        takeMiddles.Add(new TakeSubject(" is not allowed at ", new List<int> { (int)takeType.singThingPlace }));
        takeMiddles.Add(new TakeSubject(" was probably created at ", new List<int> { (int)takeType.singThingPlace }));
        takeMiddles.Add(new TakeSubject(" was probably stolen from ", new List<int> { (int)takeType.singThingPlace }));
        takeMiddles.Add(new TakeSubject(" was stolen at ", new List<int> { (int)takeType.singThingPlace }));
        takeMiddles.Add(new TakeSubject(" has never been seen in ", new List<int> { (int)takeType.singThingPlace }));
        takeMiddles.Add(new TakeSubject(" would not survive visiting ", new List<int> { (int)takeType.singThingPlace }));

        takeMiddles.Add(new TakeSubject(" was the location of ", new List<int> { (int)takeType.placeEvent }));
        takeMiddles.Add(new TakeSubject(" was forever changed by ", new List<int> { (int)takeType.placeEvent }));
        takeMiddles.Add(new TakeSubject(" was never the same after ", new List<int> { (int)takeType.placeEvent }));
        takeMiddles.Add(new TakeSubject(" had been nearly destroyed during ", new List<int> { (int)takeType.placeEvent }));
        takeMiddles.Add(new TakeSubject(" was not actually the location of ", new List<int> { (int)takeType.placeEvent }));
        takeMiddles.Add(new TakeSubject(" was entirely unaffected by ", new List<int> { (int)takeType.placeEvent }));

        takeMiddles.Add(new TakeSubject(" is the location of the headquarters for ", new List<int> { (int)takeType.placeEntity }));
        takeMiddles.Add(new TakeSubject(" is being sought after by ", new List<int> { (int)takeType.placeEntity }));
        takeMiddles.Add(new TakeSubject(" has been nearly destroyed by ", new List<int> { (int)takeType.placeEntity }));
        takeMiddles.Add(new TakeSubject(" does not allow members of ", new List<int> { (int)takeType.placeEntity }));
        takeMiddles.Add(new TakeSubject(" only allows entry to members of ", new List<int> { (int)takeType.placeEntity}));
        takeMiddles.Add(new TakeSubject(" is the founding location of ", new List<int> { (int)takeType.placeEntity }));

        takeMiddles.Add(new TakeSubject(" is the sworn enemy of ", new List<int> { (int)takeType.entityEntity }));
        takeMiddles.Add(new TakeSubject(" is constantly competing with ", new List<int> { (int)takeType.entityEntity }));
        takeMiddles.Add(new TakeSubject(" is trying to recruit members from ", new List<int> { (int)takeType.entityEntity }));
        takeMiddles.Add(new TakeSubject(" works very well with ", new List<int> { (int)takeType.entityEntity }));
        takeMiddles.Add(new TakeSubject(" has an alliance with ", new List<int> { (int)takeType.entityEntity }));
        takeMiddles.Add(new TakeSubject(" will never endorse ", new List<int> { (int)takeType.entityEntity }));
        takeMiddles.Add(new TakeSubject(" endorses ", new List<int> { (int)takeType.entityEntity }));

        takeMiddles.Add(new TakeSubject(" are more useful than ", new List<int> { (int)takeType.thingsThings }));
        takeMiddles.Add(new TakeSubject(" have been essentially replaced by ", new List<int> { (int)takeType.thingsThings }));
        takeMiddles.Add(new TakeSubject(" are more popular than ", new List<int> { (int)takeType.thingsThings }));
        takeMiddles.Add(new TakeSubject(" aren't as fun as ", new List<int> { (int)takeType.thingsThings }));
        takeMiddles.Add(new TakeSubject(" are way more fun than ", new List<int> { (int)takeType.thingsThings }));
        takeMiddles.Add(new TakeSubject(" are more in demand than ", new List<int> { (int)takeType.thingsThings }));

        takeMiddles.Add(new TakeSubject(" are more in demand than ", new List<int> { (int)takeType.groupsGroups }));
        takeMiddles.Add(new TakeSubject(" are more popular than ", new List<int> { (int)takeType.groupsGroups }));
        takeMiddles.Add(new TakeSubject(" tend to be jealous of ", new List<int> { (int)takeType.groupsGroups }));
        takeMiddles.Add(new TakeSubject(" wish they were ", new List<int> { (int)takeType.groupsGroups }));
        takeMiddles.Add(new TakeSubject(" aren't quite as wild as ", new List<int> { (int)takeType.groupsGroups }));

        takeMiddles.Add(new TakeSubject(" are always being recuited by ", new List<int> { (int)takeType.groupsEntity }));
        takeMiddles.Add(new TakeSubject(" are always being hunted by ", new List<int> { (int)takeType.groupsEntity }));
        takeMiddles.Add(new TakeSubject(" are always trying to join ", new List<int> { (int)takeType.groupsEntity }));
        takeMiddles.Add(new TakeSubject(" should never be allowed to join ", new List<int> { (int)takeType.groupsEntity }));
        takeMiddles.Add(new TakeSubject(" usually want to join ", new List<int> { (int)takeType.groupsEntity }));
        takeMiddles.Add(new TakeSubject(" rarely, if ever, want to join ", new List<int> { (int)takeType.groupsEntity }));

        takeMiddles.Add(new TakeSubject(" is more useful than ", new List<int> { (int)takeType.singThingSingThing }));
        takeMiddles.Add(new TakeSubject(" is worth more than ", new List<int> { (int)takeType.singThingSingThing }));
        takeMiddles.Add(new TakeSubject(" cannot compete with ", new List<int> { (int)takeType.singThingSingThing }));
        takeMiddles.Add(new TakeSubject(" is more well-known than ", new List<int> { (int)takeType.singThingSingThing }));
        takeMiddles.Add(new TakeSubject(" is more important than ", new List<int> { (int)takeType.singThingSingThing }));
        takeMiddles.Add(new TakeSubject(" isn't as important as ", new List<int> { (int)takeType.singThingSingThing }));

        takeMiddles.Add(new TakeSubject(" is more important than all of the ", new List<int> { (int)takeType.singThingThings }));
        takeMiddles.Add(new TakeSubject(" is a result of blending together all of the ", new List<int> { (int)takeType.singThingThings }));
        takeMiddles.Add(new TakeSubject(" isn't as important as the ", new List<int> { (int)takeType.singThingThings }));
        takeMiddles.Add(new TakeSubject(" was inspired by the ", new List<int> { (int)takeType.singThingThings }));
        takeMiddles.Add(new TakeSubject(" was definitely not inspired by the ", new List<int> { (int)takeType.singThingThings }));
        takeMiddles.Add(new TakeSubject(" is way better than ", new List<int> { (int)takeType.singThingThings }));

        takeMiddles.Add(new TakeSubject(" is more important than all of the ", new List<int> { (int)takeType.singThingGroups }));
        takeMiddles.Add(new TakeSubject(" is wanted by all of the ", new List<int> { (int)takeType.singThingGroups }));
        takeMiddles.Add(new TakeSubject(" is being searched for by the ", new List<int> { (int)takeType.singThingGroups }));
        takeMiddles.Add(new TakeSubject(" will be destroyed by the ", new List<int> { (int)takeType.singThingGroups }));
        takeMiddles.Add(new TakeSubject(" might never be seen by the ", new List<int> { (int)takeType.singThingGroups }));
        takeMiddles.Add(new TakeSubject(" will never be contaminated the ", new List<int> { (int)takeType.singThingGroups }));

        takeMiddles.Add(new TakeSubject(" is being searched for by ", new List<int> { (int)takeType.singThingEntity }));
        takeMiddles.Add(new TakeSubject(" is not supported by ", new List<int> { (int)takeType.singThingEntity }));
        takeMiddles.Add(new TakeSubject(" is well-supported by ", new List<int> { (int)takeType.singThingEntity }));
        takeMiddles.Add(new TakeSubject(" is wanted by ", new List<int> { (int)takeType.singThingEntity }));
        takeMiddles.Add(new TakeSubject(" has never been wanted by ", new List<int> { (int)takeType.singThingEntity }));
        takeMiddles.Add(new TakeSubject(" has always been endorsed by ", new List<int> { (int)takeType.singThingEntity }));

        takeMiddles.Add(new TakeSubject(" was secretly arranged by ", new List<int> { (int)takeType.eventPerson }));
        takeMiddles.Add(new TakeSubject(" would not have been possible without ", new List<int> { (int)takeType.eventPerson }));
        takeMiddles.Add(new TakeSubject(" was not supported by ", new List<int> { (int)takeType.eventPerson }));
        takeMiddles.Add(new TakeSubject(" was heavily promoted by ", new List<int> { (int)takeType.eventPerson }));
        takeMiddles.Add(new TakeSubject(" was not graced with the presence of ", new List<int> { (int)takeType.eventPerson }));
        takeMiddles.Add(new TakeSubject(" was, surprisingly, graced with the presence of ", new List<int> { (int)takeType.eventPerson }));

        takeMiddles.Add(new TakeSubject(" would not have been possible without ", new List<int> { (int)takeType.eventSingThing }));
        takeMiddles.Add(new TakeSubject(" would have been possible without ", new List<int> { (int)takeType.eventSingThing }));
        takeMiddles.Add(new TakeSubject(" would have been better with ", new List<int> { (int)takeType.eventSingThing }));
        takeMiddles.Add(new TakeSubject(" would have been better without ", new List<int> { (int)takeType.eventSingThing }));
        takeMiddles.Add(new TakeSubject(" might have been cancelled without ", new List<int> { (int)takeType.eventSingThing }));
        takeMiddles.Add(new TakeSubject(" would have been ruined by the presence of ", new List<int> { (int)takeType.eventSingThing }));

        takeMiddles.Add(new TakeSubject(" would not have been possible without the ", new List<int> { (int)takeType.eventGroups }));
        takeMiddles.Add(new TakeSubject(" would have been possible without the ", new List<int> { (int)takeType.eventGroups }));
        takeMiddles.Add(new TakeSubject(" would have been better without the ", new List<int> { (int)takeType.eventGroups }));
        takeMiddles.Add(new TakeSubject(" would have been better with the ", new List<int> { (int)takeType.eventGroups }));
        takeMiddles.Add(new TakeSubject(" would have been ruined by the presence of ", new List<int> { (int)takeType.eventGroups }));
        takeMiddles.Add(new TakeSubject(" would have been cancelled without ", new List<int> { (int)takeType.eventGroups }));

        takeMiddles.Add(new TakeSubject(" would not have been possible without ", new List<int> { (int)takeType.eventEntity }));
        takeMiddles.Add(new TakeSubject(" was secretly arranged by ", new List<int> { (int)takeType.eventEntity }));
        takeMiddles.Add(new TakeSubject(" was not supported by ", new List<int> { (int)takeType.eventEntity }));
        takeMiddles.Add(new TakeSubject(" was heavily promoted by ", new List<int> { (int)takeType.eventEntity }));
        takeMiddles.Add(new TakeSubject(" would have been ruined by the presence of ", new List<int> { (int)takeType.eventEntity }));
        takeMiddles.Add(new TakeSubject(" was graced with the presence of ", new List<int> { (int)takeType.eventEntity }));

        takeMiddles.Add(new TakeSubject(" was a better time than ", new List<int> { (int)takeType.eventEvent }));
        takeMiddles.Add(new TakeSubject(" was overshadowed by ", new List<int> { (int)takeType.eventEvent }));
        takeMiddles.Add(new TakeSubject(" was not as fun as ", new List<int> { (int)takeType.eventEvent }));
        takeMiddles.Add(new TakeSubject(" was way more fun than ", new List<int> { (int)takeType.eventEvent }));
        takeMiddles.Add(new TakeSubject(" was not a better time than ", new List<int> { (int)takeType.eventEvent }));
        takeMiddles.Add(new TakeSubject(" was more popular than ", new List<int> { (int)takeType.eventEvent }));
        takeMiddles.Add(new TakeSubject(" was not as popular as ", new List<int> { (int)takeType.eventEvent }));


        GetMiddleRanges();
    }

    private void GetMiddleRanges()
    {
        personPersonRange.SetFirst(0);
        for(int i = 0; i < takeMiddles.Count; i++)
        {
            if(takeMiddles[i].GetCategories().Contains((int)takeType.personPlace) && personPersonRange.GetLastIndex() == -1)
            {
                personPersonRange.SetLast(i - 1);
                personPlaceRange.SetFirst(i);
            }
            else if(takeMiddles[i].GetCategories().Contains((int)takeType.personGroups) && personPlaceRange.GetLastIndex() == -1)
            {
                personPlaceRange.SetLast(i - 1);
                personGroupsRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.personThings) && personGroupsRange.GetLastIndex() == -1)
            {
                personGroupsRange.SetLast(i - 1);
                personThingsRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.personSingThing) && personThingsRange.GetLastIndex() == -1)
            {
                personThingsRange.SetLast(i - 1);
                personSingThingRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.personEvent) && personSingThingRange.GetLastIndex() == -1)
            {
                personSingThingRange.SetLast(i - 1);
                personEventRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.personEntity) && personEventRange.GetLastIndex() == -1)
            {
                personEventRange.SetLast(i - 1);
                personEntityRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.placePerson) && personEntityRange.GetLastIndex() == -1)
            {
                personEntityRange.SetLast(i - 1);
                placePersonRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.placePlace) && placePersonRange.GetLastIndex() == -1)
            {
                placePersonRange.SetLast(i - 1);
                placePlaceRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.placeThings) && placePlaceRange.GetLastIndex() == -1)
            {
                placePlaceRange.SetLast(i - 1);
                placeThingsRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.placeGroups) && placeThingsRange.GetLastIndex() == -1)
            {
                placeThingsRange.SetLast(i - 1);
                placeGroupsRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.placeSingThing) && placeGroupsRange.GetLastIndex() == -1)
            {
                placeGroupsRange.SetLast(i - 1);
                placeSingThingRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.singThingPlace) && placeSingThingRange.GetLastIndex() == -1)
            {
                placeSingThingRange.SetLast(i - 1);
                singThingPlaceRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.placeEvent) && singThingPlaceRange.GetLastIndex() == -1)
            {
                singThingPlaceRange.SetLast(i - 1);
                placeEventRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.placeEntity) && placeEventRange.GetLastIndex() == -1)
            {
                placeEventRange.SetLast(i - 1);
                placeEntityRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.entityEntity) && placeEntityRange.GetLastIndex() == -1)
            {
                placeEntityRange.SetLast(i - 1);
                entityEntityRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.thingsThings) && entityEntityRange.GetLastIndex() == -1)
            {
                entityEntityRange.SetLast(i - 1);
                thingsThingsRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.groupsGroups) && thingsThingsRange.GetLastIndex() == -1)
            {
                thingsThingsRange.SetLast(i - 1);
                groupsGroupsRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.singThingSingThing) && groupsGroupsRange.GetLastIndex() == -1)
            {
                groupsGroupsRange.SetLast(i - 1);
                singThingSingThingRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.singThingThings) && singThingSingThingRange.GetLastIndex() == -1)
            {
                singThingSingThingRange.SetLast(i - 1);
                singThingThingsRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.singThingGroups) && singThingThingsRange.GetLastIndex() == -1)
            {
                singThingThingsRange.SetLast(i - 1);
                singThingGroupsRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.singThingEntity) && singThingGroupsRange.GetLastIndex() == -1)
            {
                singThingGroupsRange.SetLast(i - 1);
                singThingEntityRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.eventPerson) && singThingEntityRange.GetLastIndex() == -1)
            {
                singThingEntityRange.SetLast(i - 1);
                eventPersonRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.eventSingThing) && eventPersonRange.GetLastIndex() == -1)
            {
                eventPersonRange.SetLast(i - 1);
                eventSingThingRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.eventGroups) && eventSingThingRange.GetLastIndex() == -1)
            {
                eventSingThingRange.SetLast(i - 1);
                eventGroupsRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.eventEntity) && eventGroupsRange.GetLastIndex() == -1)
            {
                eventGroupsRange.SetLast(i - 1);
                eventEntityRange.SetFirst(i);
            }
            else if (takeMiddles[i].GetCategories().Contains((int)takeType.eventEvent) && eventEntityRange.GetLastIndex() == -1)
            {
                eventEntityRange.SetLast(i - 1);
                eventEventRange.SetFirst(i);
            }
            eventEventRange.SetLast(takeMiddles.Count - 1);
        }
    }

    private TakeSubject GetPerson()
    {
        return takeTypeList[(int)subject.person][Random.Range(0, takeTypeList[(int)subject.person].Count - 1)];
    }

    private TakeSubject GetPlace()
    {
        return takeTypeList[(int)subject.place][Random.Range(0, takeTypeList[(int)subject.place].Count - 1)];
    }

    private TakeSubject GetThings(int type)
    {
        // type == 0: any element
        // type == 1: No informal groups
        // type == 2: Informal groups
        if (type == 0)
        {
            return takeTypeList[(int)subject.things][Random.Range(0, takeTypeList[(int)subject.things].Count - 1)];
        }
        else if (type == 1)
        {
            TakeSubject takeSubject = takeTypeList[(int)subject.things][Random.Range(0, takeTypeList[(int)subject.things].Count - 1)];
            while (takeSubject.GetCategories().Contains((int)category.informalGroup))
            {
                takeSubject = takeTypeList[(int)subject.things][Random.Range(0, takeTypeList[(int)subject.things].Count - 1)];
            }
            return takeSubject;
        }
        else
        {
            TakeSubject takeSubject = takeTypeList[(int)subject.things][Random.Range(0, takeTypeList[(int)subject.things].Count - 1)];
            while (!takeSubject.GetCategories().Contains((int)category.informalGroup))
            {
                takeSubject = takeTypeList[(int)subject.things][Random.Range(0, takeTypeList[(int)subject.things].Count - 1)];
            }
            return takeSubject;
        }
    }

    private TakeSubject GetHistEvent()
    {
        return takeTypeList[(int)subject.histEvent][Random.Range(0, takeTypeList[(int)subject.histEvent].Count - 1)];
    }

    private TakeSubject GetSingThing()
    {
        return takeTypeList[(int)subject.singThing][Random.Range(0, takeTypeList[(int)subject.singThing].Count - 1)];
    }

    private TakeSubject GetEntity()
    {
        return takeTypeList[(int)subject.entity][Random.Range(0, takeTypeList[(int)subject.entity].Count - 1)];
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(Generate());
        }
    }

    public void SetCategoryValues()
    {
        for (int i = 0; i < categoryValues.Length; i++)
        {
            
            categoryValues[i] = Random.Range(0, 11);
            Debug.Log("i = " + i + ", value = " + categoryValues[i]);
        }
    }

    public int[] GetCategoryValues()
    {
        return categoryValues;
    }

    public HotTake Generate()
    {
        int value = 0;

        TakeSubject take = takeMiddles[Random.Range(0, takeMiddles.Count - 1)];
        if (take.GetCategories().Contains((int)takeType.personPerson))
        {
            TakeSubject person = GetPerson();
            TakeSubject person2 = GetPerson();
            for(int i  = 0; i < person.GetCategories().Count; i++)
            {
                value += categoryValues[(int)person.GetCategories()[i]];
            }
            for (int i = 0; i < person2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)person2.GetCategories()[i]];
            }
            return new HotTake(person.GetName() + take.GetName() + person2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.personPlace))
        {
            TakeSubject person = GetPerson();
            TakeSubject place = GetPlace();
            for (int i = 0; i < person.GetCategories().Count; i++)
            {
                value += categoryValues[(int)person.GetCategories()[i]];
            }
            for (int i = 0; i < place.GetCategories().Count; i++)
            {
                value += categoryValues[(int)place.GetCategories()[i]];
            }
            return new HotTake(person.GetName() + take.GetName() + place.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.personGroups))
        {
            TakeSubject person = GetPerson();
            TakeSubject group = GetThings(2);
            for (int i = 0; i < person.GetCategories().Count; i++)
            {

                value += categoryValues[(int)person.GetCategories()[i]];
            }
            for (int i = 0; i < group.GetCategories().Count; i++)
            {
                if ((int)group.GetCategories()[i] != (int)category.informalGroup)
                {
                    value += categoryValues[(int)group.GetCategories()[i]];
                }
            }
            return new HotTake(person.GetName() + take.GetName() + group.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.personThings))
        {
            TakeSubject person = GetPerson();
            TakeSubject things = GetThings(1);
            for (int i = 0; i < person.GetCategories().Count; i++)
            {
                value += categoryValues[(int)person.GetCategories()[i]];
            }
            for (int i = 0; i < things.GetCategories().Count; i++)
            {
                value += categoryValues[(int)things.GetCategories()[i]];
            }
            return new HotTake(person.GetName() + take.GetName() + things.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.personEvent))
        {
            TakeSubject person = GetPerson();
            TakeSubject histEvent = GetHistEvent();
            for (int i = 0; i < person.GetCategories().Count; i++)
            {
                value += categoryValues[(int)person.GetCategories()[i]];
            }
            for (int i = 0; i < histEvent.GetCategories().Count; i++)
            {
                value += categoryValues[(int)histEvent.GetCategories()[i]];
            }
            return new HotTake(person.GetName() + take.GetName() + histEvent.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.personSingThing))
        {
            TakeSubject person = GetPerson();
            TakeSubject thing = GetSingThing();
            for (int i = 0; i < person.GetCategories().Count; i++)
            {
                value += categoryValues[(int)person.GetCategories()[i]];
            }
            for (int i = 0; i < thing.GetCategories().Count; i++)
            {
                value += categoryValues[(int)thing.GetCategories()[i]];
            }
            return new HotTake(person.GetName() + take.GetName() + thing.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.personEntity))
        {
            TakeSubject person = GetPerson();
            TakeSubject entity = GetEntity();
            for (int i = 0; i < person.GetCategories().Count; i++)
            {
                value += categoryValues[(int)person.GetCategories()[i]];
            }
            for (int i = 0; i < entity.GetCategories().Count; i++)
            {
                value += categoryValues[(int)entity.GetCategories()[i]];
            }
            return new HotTake(person.GetName() + take.GetName() + entity.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.placePerson))
        {
            TakeSubject place = GetPlace();
            TakeSubject person2 = GetPerson();
            for (int i = 0; i < place.GetCategories().Count; i++)
            {
                value += categoryValues[(int)place.GetCategories()[i]];
            }
            for (int i = 0; i < person2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)person2.GetCategories()[i]];
            }
            return new HotTake(place.GetName() + take.GetName() + person2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.placeGroups))
        {
            TakeSubject place = GetPlace();
            TakeSubject group = GetThings(2);
            for (int i = 0; i < place.GetCategories().Count; i++)
            {
                value += categoryValues[(int)place.GetCategories()[i]];
            }
            for (int i = 0; i < group.GetCategories().Count; i++)
            {
                if ((int)group.GetCategories()[i] != (int)category.informalGroup)
                {
                    value += categoryValues[(int)group.GetCategories()[i]];
                }
            }
            return new HotTake(place.GetName() + take.GetName() + group.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.placeThings))
        {
            TakeSubject place = GetPlace();
            TakeSubject things = GetThings(1);
            for (int i = 0; i < place.GetCategories().Count; i++)
            {
                value += categoryValues[(int)place.GetCategories()[i]];
            }
            for (int i = 0; i < things.GetCategories().Count; i++)
            {
                value += categoryValues[(int)things.GetCategories()[i]];
            }
            return new HotTake(place.GetName() + take.GetName() + things.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.placePlace))
        {
            TakeSubject place = GetPlace();
            TakeSubject place2 = GetPlace();
            for (int i = 0; i < place.GetCategories().Count; i++)
            {
                value += categoryValues[(int)place.GetCategories()[i]];
            }
            for (int i = 0; i < place2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)place2.GetCategories()[i]];
            }
            return new HotTake(place.GetName() + take.GetName() + place2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.placeEvent))
        {
            TakeSubject place = GetPlace();
            TakeSubject histEvent = GetHistEvent();
            for (int i = 0; i < place.GetCategories().Count; i++)
            {
                value += categoryValues[(int)place.GetCategories()[i]];
            }
            for (int i = 0; i < histEvent.GetCategories().Count; i++)
            {
                value += categoryValues[(int)histEvent.GetCategories()[i]];
            }
            return new HotTake(place.GetName() + take.GetName() + histEvent.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.placeSingThing))
        {
            TakeSubject takeSub1 = GetPlace();
            TakeSubject takeSub2 = GetSingThing();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.placeEntity))
        {
            TakeSubject takeSub1 = GetPlace();
            TakeSubject takeSub2 = GetEntity();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.eventPerson))
        {
            TakeSubject takeSub1 = GetHistEvent();
            TakeSubject takeSub2 = GetPerson();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.eventPlace))
        {
            TakeSubject takeSub1 = GetHistEvent();
            TakeSubject takeSub2 = GetPlace();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.eventThings))
        {
            TakeSubject takeSub1 = GetHistEvent();
            TakeSubject takeSub2 = GetThings(1);
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.eventGroups))
        {
            TakeSubject takeSub1 = GetHistEvent();
            TakeSubject takeSub2 = GetThings(2);
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                if ((int)takeSub2.GetCategories()[i] != (int)category.informalGroup)
                {
                    value += categoryValues[(int)takeSub2.GetCategories()[i]];
                }
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.eventEvent))
        {
            TakeSubject takeSub1 = GetHistEvent();
            TakeSubject takeSub2 = GetHistEvent();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.eventSingThing))
        {
            TakeSubject takeSub1 = GetHistEvent();
            TakeSubject takeSub2 = GetSingThing();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.eventEntity))
        {
            TakeSubject takeSub1 = GetHistEvent();
            TakeSubject takeSub2 = GetEntity();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.singThingPerson))
        {
            TakeSubject takeSub1 = GetSingThing();
            TakeSubject takeSub2 = GetPerson();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.singThingPlace))
        {
            TakeSubject takeSub1 = GetSingThing();
            TakeSubject takeSub2 = GetPlace();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.singThingThings))
        {
            TakeSubject takeSub1 = GetSingThing();
            TakeSubject takeSub2 = GetThings(1);
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.singThingGroups))
        {
            TakeSubject takeSub1 = GetSingThing();
            TakeSubject takeSub2 = GetThings(2);
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                if ((int)takeSub2.GetCategories()[i] != (int)category.informalGroup)
                { 
                    value += categoryValues[(int)takeSub2.GetCategories()[i]];
                }
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.singThingEvent))
        {
            TakeSubject takeSub1 = GetSingThing();
            TakeSubject takeSub2 = GetHistEvent();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.singThingSingThing))
        {
            TakeSubject takeSub1 = GetSingThing();
            TakeSubject takeSub2 = GetSingThing();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.singThingEntity))
        {
            TakeSubject takeSub1 = GetSingThing();
            TakeSubject takeSub2 = GetEntity();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.entityPerson))
        {
            TakeSubject takeSub1 = GetEntity();
            TakeSubject takeSub2 = GetPerson();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.entityPlace))
        {
            TakeSubject takeSub1 = GetEntity();
            TakeSubject takeSub2 = GetPlace();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.entityThings))
        {
            TakeSubject takeSub1 = GetEntity();
            TakeSubject takeSub2 = GetThings(1);
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.entityGroups))
        {
            TakeSubject takeSub1 = GetEntity();
            TakeSubject takeSub2 = GetThings(2);
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                if ((int)takeSub2.GetCategories()[i] != (int)category.informalGroup)
                {
                    value += categoryValues[(int)takeSub2.GetCategories()[i]];
                }
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.entityEvent))
        {
            TakeSubject takeSub1 = GetEntity();
            TakeSubject takeSub2 = GetHistEvent();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.entitySingThing))
        {
            TakeSubject takeSub1 = GetEntity();
            TakeSubject takeSub2 = GetSingThing();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.entityEntity))
        {
            TakeSubject takeSub1 = GetEntity();
            TakeSubject takeSub2 = GetEntity();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.thingsPerson))
        {
            TakeSubject takeSub1 = GetThings(1);
            TakeSubject takeSub2 = GetPerson();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.thingsPlace))
        {
            TakeSubject takeSub1 = GetThings(1);
            TakeSubject takeSub2 = GetPlace();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.thingsThings))
        {
            TakeSubject takeSub1 = GetThings(1);
            TakeSubject takeSub2 = GetThings(1);
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.thingsGroup))
        {
            TakeSubject takeSub1 = GetThings(1);
            TakeSubject takeSub2 = GetThings(2);
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                if ((int)takeSub2.GetCategories()[i] != (int)category.informalGroup)
                {
                    value += categoryValues[(int)takeSub2.GetCategories()[i]];
                }
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.thingsEvent))
        {
            TakeSubject takeSub1 = GetThings(1);
            TakeSubject takeSub2 = GetHistEvent();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.thingsSingThing))
        {
            TakeSubject takeSub1 = GetThings(1);
            TakeSubject takeSub2 = GetSingThing();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.thingsEntity))
        {
            TakeSubject takeSub1 = GetThings(1);
            TakeSubject takeSub2 = GetEntity();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub1.GetCategories()[i]];
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.groupsPerson))
        {
            TakeSubject takeSub1 = GetThings(2);
            TakeSubject takeSub2 = GetPerson();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                if ((int)takeSub1.GetCategories()[i] != (int)category.informalGroup)
                {
                    value += categoryValues[(int)takeSub1.GetCategories()[i]];
                }
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.groupsPlace))
        {
            TakeSubject takeSub1 = GetThings(2);
            TakeSubject takeSub2 = GetPlace();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                if ((int)takeSub1.GetCategories()[i] != (int)category.informalGroup)
                {
                    value += categoryValues[(int)takeSub1.GetCategories()[i]];
                }
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.groupsThings))
        {
            TakeSubject takeSub1 = GetThings(2);
            TakeSubject takeSub2 = GetThings(1);
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                if ((int)takeSub1.GetCategories()[i] != (int)category.informalGroup)
                {
                    value += categoryValues[(int)takeSub1.GetCategories()[i]];
                }
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.groupsGroups))
        {
            TakeSubject takeSub1 = GetThings(2);
            TakeSubject takeSub2 = GetThings(2);
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                if ((int)takeSub1.GetCategories()[i] != (int)category.informalGroup)
                {
                    value += categoryValues[(int)takeSub1.GetCategories()[i]];
                }
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                if ((int)takeSub2.GetCategories()[i] != (int)category.informalGroup)
                {
                    value += categoryValues[(int)takeSub2.GetCategories()[i]];
                }
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.groupsEvent))
        {
            TakeSubject takeSub1 = GetThings(2);
            TakeSubject takeSub2 = GetHistEvent();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                if ((int)takeSub1.GetCategories()[i] != (int)category.informalGroup)
                {
                    value += categoryValues[(int)takeSub1.GetCategories()[i]];
                }
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.groupsSingThing))
        {
            TakeSubject takeSub1 = GetThings(2);
            TakeSubject takeSub2 = GetSingThing();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                if ((int)takeSub1.GetCategories()[i] != (int)category.informalGroup)
                {
                    value += categoryValues[(int)takeSub1.GetCategories()[i]];
                }
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.groupsEvent))
        {
            TakeSubject takeSub1 = GetThings(2);
            TakeSubject takeSub2 = GetHistEvent();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                if ((int)takeSub1.GetCategories()[i] != (int)category.informalGroup)
                {
                    value += categoryValues[(int)takeSub1.GetCategories()[i]];
                }
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else if (take.GetCategories().Contains((int)takeType.groupsEntity))
        {
            TakeSubject takeSub1 = GetThings(2);
            TakeSubject takeSub2 = GetEntity();
            for (int i = 0; i < takeSub1.GetCategories().Count; i++)
            {
                if ((int)takeSub1.GetCategories()[i] != (int)category.informalGroup)
                {
                    value += categoryValues[(int)takeSub1.GetCategories()[i]];
                }
            }
            for (int i = 0; i < takeSub2.GetCategories().Count; i++)
            {
                value += categoryValues[(int)takeSub2.GetCategories()[i]];
            }
            return new HotTake(takeSub1.GetName() + take.GetName() + takeSub2.GetName() + ".", value);
        }
        else
        {
            return new HotTake("", 0);
        }
    }

    public string[] GetOmerSentences()
    {
        int sub1;
        int sub2;
        string subject1;
        string subject2;
        TakeSubject middle;
        string[] omer = new string[4];
        List<string> middles = new List<string>();

        sub1 = Random.Range(0, 4);
        if (sub1 == (int)subject.things)
        {
            sub2 = 2;
        }
        else if (sub1 == (int)subject.histEvent)
        {
            int cat = Random.Range(0, 3);
            if (cat == 0)
            {
                sub2 = (int)subject.person;
            }
            else if (cat == 1)
            {
                sub2 = (int)subject.histEvent;
            }
            else if (cat == 2)
            {
                sub2 = (int)subject.singThing;
            }
            else
            {
                sub2 = (int)subject.entity;
            }
        }
        else if (sub1 == (int)subject.singThing)
        {
            int cat = Random.Range(0, 3);
            if (cat == 0)
            {
                sub2 = (int)subject.place;
            }
            else if (cat == 1)
            {
                sub2 = (int)subject.things;
            }
            else if (cat == 2)
            {
                sub2 = (int)subject.singThing;
            }
            else
            {
                sub2 = (int)subject.entity;
            }
        }
        else
        {
            sub2 = Random.Range(0, 5);
        }

        //Get Subject1
        if (sub1 == 0)
        {
            subject1 = GetPerson().GetName();
        }
        else if (sub1 == 1)
        {
            subject1 = GetPlace().GetName();
        }
        else if (sub1 == 2)
        {
            subject1 = GetThings(1).GetName();
        }
        else if (sub1 == 3)
        {
            subject1 = GetHistEvent().GetName();
        }
        else if (sub1 == 4)
        {
            subject1 = GetSingThing().GetName();
        }
        else
        {
            subject1 = GetEntity().GetName();
        }

        //Get subject2
        if (sub2 == 0)
        {
            subject2 = GetPerson().GetName();
        }
        else if (sub2 == 1)
        {
            subject2 = GetPlace().GetName();
        }
        else if (sub2 == 2)
        {
            subject2 = GetThings(1).GetName();
        }
        else if (sub2 == 3)
        {
            subject2 = GetHistEvent().GetName();
        }
        else if (sub2 == 4)
        {
            subject2 = GetSingThing().GetName();
        }
        else
        {
            subject2 = GetEntity().GetName();
        }
        for (int i = 0; i < 4; i++)
        {

            middle = GetMiddle(sub1, sub2);

            while (middles.Contains(middle.GetName()))
            {
                middle = GetMiddle(sub1, sub2);
                Debug.Log("Oh No! this is already used: " + middle.GetName());
            }
            middles.Add(middle.GetName());

            omer[i] = subject1 + middle.GetName() + subject2 + ".";
        }
        return omer;
    }

    private TakeSubject GetMiddle(int sub1, int sub2)
    {
        TakeSubject middle;
        if (sub1 == (int)subject.person && sub2 == (int)subject.person)
        {
            middle = takeMiddles[Random.Range(personPersonRange.GetFirstIndex(), personPersonRange.GetLastIndex())];
        }
        else if (sub1 == (int)subject.person && sub2 == (int)subject.place)
        {
            middle = takeMiddles[Random.Range(personPlaceRange.GetFirstIndex(), personPlaceRange.GetLastIndex())];
        }
        else if (sub1 == (int)subject.person && sub2 == (int)subject.things)
        {
            middle = takeMiddles[Random.Range(personThingsRange.GetFirstIndex(), personThingsRange.GetLastIndex())];
        }
        else if (sub1 == (int)subject.person && sub2 == (int)subject.histEvent)
        {
            middle = takeMiddles[Random.Range(personEventRange.GetFirstIndex(), personEventRange.GetLastIndex())];
        }
        else if (sub1 == (int)subject.person && sub2 == (int)subject.singThing)
        {
            middle = takeMiddles[Random.Range(personSingThingRange.GetFirstIndex(), personSingThingRange.GetLastIndex())];
        }
        else if (sub1 == (int)subject.person && sub2 == (int)subject.entity)
        {
            middle = takeMiddles[Random.Range(personEntityRange.GetFirstIndex(), personEntityRange.GetLastIndex())];
        }
        else if (sub1 == (int)subject.place && sub2 == (int)subject.person)
        {
            middle = takeMiddles[Random.Range(placePersonRange.GetFirstIndex(), placePersonRange.GetLastIndex())];
        }
        else if (sub1 == (int)subject.place && sub2 == (int)subject.things)
        {
            middle = takeMiddles[Random.Range(placeThingsRange.GetFirstIndex(), placeThingsRange.GetLastIndex())];
        }
        else if (sub1 == (int)subject.place && sub2 == (int)subject.place)
        {
            middle = takeMiddles[Random.Range(placePlaceRange.GetFirstIndex(), placePlaceRange.GetLastIndex())];
        }
        else if (sub1 == (int)subject.place && sub2 == (int)subject.singThing)
        {
            middle = takeMiddles[Random.Range(placeSingThingRange.GetFirstIndex(), placeSingThingRange.GetLastIndex())];
        }
        else if (sub1 == (int)subject.place && sub2 == (int)subject.entity)
        {
            middle = takeMiddles[Random.Range(placeEntityRange.GetFirstIndex(), placeEntityRange.GetLastIndex())];
        }
        else if (sub1 == (int)subject.things && sub2 == (int)subject.things)
        {
            middle = takeMiddles[Random.Range(thingsThingsRange.GetFirstIndex(), thingsThingsRange.GetLastIndex())];
        }
        else if (sub1 == (int)subject.histEvent && sub2 == (int)subject.person)
        {
            middle = takeMiddles[Random.Range(eventPersonRange.GetFirstIndex(), eventPersonRange.GetLastIndex())];
        }
        else if (sub1 == (int)subject.histEvent && sub2 == (int)subject.histEvent)
        {
            middle = takeMiddles[Random.Range(eventEventRange.GetFirstIndex(), eventEventRange.GetLastIndex())];
        }
        else if (sub1 == (int)subject.singThing && sub2 == (int)subject.place)
        {
            middle = takeMiddles[Random.Range(singThingPlaceRange.GetFirstIndex(), singThingPlaceRange.GetLastIndex())];
        }
        else if (sub1 == (int)subject.singThing && sub2 == (int)subject.things)
        {
            middle = takeMiddles[Random.Range(singThingThingsRange.GetFirstIndex(), singThingThingsRange.GetLastIndex())];
        }
        else if (sub1 == (int)subject.singThing && sub2 == (int)subject.singThing)
        {
            middle = takeMiddles[Random.Range(singThingSingThingRange.GetFirstIndex(), singThingSingThingRange.GetLastIndex())];
        }
        else 
        {
            middle = takeMiddles[Random.Range(singThingEntityRange.GetFirstIndex(), singThingEntityRange.GetLastIndex())];
        }
        return middle;
    }
}