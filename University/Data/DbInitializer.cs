using System;
using System.Linq;

namespace University.Models
{
    public class DbInitializer
    {
        public static void Initialize(UniversityContext context)
        {
            context.Database.EnsureCreated();

            if (context.Faculties.Any())
            {
                return;
            }

            int faculty_number = 5;
            int teacher_number = 30;
            int typeOfDiscipline_number = 2;
            int pulpit_number = 20;
            int specialty_number = 20;
            
            int discipline_number = 20;

            Random randObj = new Random(1);

             
             string[] facultyName = { "ЭФ", "ФАИС", "ГЭФ", "МТФ", "МСФ" };

             context.Faculties.Add(
                 new Faculty()
                 {
                     NameFaculty = facultyName[0]
                 });
             context.Faculties.Add(
                 new Faculty()
                 {
                     NameFaculty = facultyName[1]
                 });
             context.Faculties.Add(
                 new Faculty()
                 {
                     NameFaculty = facultyName[2]
                 });
             context.Faculties.Add(
                 new Faculty()
                 {
                     NameFaculty = facultyName[3]
                 });
             context.Faculties.Add(
                 new Faculty()
                 {
                     NameFaculty = facultyName[4]
                 });
             context.SaveChanges();


             string Name;
             string Position;
             int PhoneNumber;

             string[] name_voc = { "Юрий Васильевич", "Петр Иванович", "Иван Иванович", "Василий Петрович", "Павел Кузьмич", "Вячеслав Данилович", "Снежана Моисеевна", "Денис Поликарпович", "Екатерина Мифодьевна"};
             string[] position = { "Преподаватель ", "Ст.Преподаватель ", "Доцент ", "Ассистент " };
             int count_name_voc = name_voc.GetLength(0);
             int count_position_voc = position.GetLength(0);

             for (int teacherID = 1; teacherID <= teacher_number; teacherID++)
             {
                 Name = name_voc[randObj.Next(count_name_voc)];
                 Position = position[randObj.Next(count_position_voc)];
                 PhoneNumber = randObj.Next(1000000) + 9999999;
                 context.Teachers.Add(
                 new Teacher()
                 {
                     Position = Position,
                     FullName = Name,
                     Phone = PhoneNumber
                 });
             }
             context.SaveChanges();
             
           
          
             string[] nameTypeOfDiscipline = { "Общеобразовательная", "Специальная" };

             context.TypeOfDisciplins.Add(
                 new TypeOfDiscipline()
                 {
                     NameTypeOfDiscipline = nameTypeOfDiscipline[0]
                 });
             context.TypeOfDisciplins.Add(
                 new TypeOfDiscipline()
                 {
                     NameTypeOfDiscipline = nameTypeOfDiscipline[1]
                 });

             context.SaveChanges();

          
            int facultyID;
            string namePulpit;
            string kindOfChair;

            string[] namepulpit_voc = { "Информационных", "Информатики", "Пром-Электроники", "Физики","Математики", "Ин-языков" };
            string[] kindOfChair_voc = { "Выпускающая", "Ощеобразовательная" };
            int count_namepulpit_voc = namepulpit_voc.GetLength(0);
            int count_kindOfChair_voc = kindOfChair_voc.GetLength(0);

            for (int pulpitID = 1; pulpitID <= pulpit_number; pulpitID++)
            {
                namePulpit = namepulpit_voc[randObj.Next(count_namepulpit_voc)];
                kindOfChair = kindOfChair_voc[randObj.Next(count_kindOfChair_voc)];
                facultyID = randObj.Next(1, faculty_number - 1);
                context.Pulpits.Add(
                new Pulpit()
                {
                    NamePulpit = namePulpit,
                    KindOfChair =kindOfChair,                    
                    FacultyID = facultyID
                });
            }
            context.SaveChanges();


                        string nameSpecialty;
                        int course;
                        int semester;
                        int PulpitID;

                        string[] nameSpecialty_voc = { "Информационные системы", "Пром-электроника ", "Информационные технологии ", "Электор-привод", "Электрические сети", "Машиностроение", "Сельхозмашины" };
                        int count_nameSpecialty_voc = nameSpecialty_voc.GetLength(0);
                        

                        for (int pulpitID = 1; pulpitID <= pulpit_number; pulpitID++)
                        {
                            nameSpecialty = nameSpecialty_voc[randObj.Next(count_nameSpecialty_voc)];
                            course = randObj.Next(1, 5);
                            semester = randObj.Next(1, 10);
                            PulpitID = randObj.Next(1, pulpit_number-1);
                            context.Speciaties.Add(
                            new Specialty()
                            {
                                NameSpecialty = nameSpecialty,
                                Course = course,
                                Semester = semester,
                                PulpitID = PulpitID

                            });
                        }
                        context.SaveChanges();


             int NumberOfHoursOfLectures;
             int NumberOfHoursOfPractice;
             int TeacherID;
             int TypeOfDisciplineID;
             int SpecialtyID;

             string NameDiscipline;
             string TypeOfRporting;

             string[] nameDiscipline_voc = { "Математика", "Физика", "ООП", "Веб-сайты", "Физкультура ", "История ", "Бел.яз ", "Английский яз. ", "Java ", "ОММФС " };
             int count_nameDiscipline_voc = nameDiscipline_voc.GetLength(0);
             string[] typeOfRporting_voc = { "Экзамен", "Зачет", "Диф-зачет","Защита" };
             int count_typeOfRporting_voc = typeOfRporting_voc.GetLength(0);

             for (int disciplineID = 1; disciplineID <= discipline_number; disciplineID++)
             {

                         NameDiscipline = nameDiscipline_voc[randObj.Next(count_nameDiscipline_voc)];
                         TypeOfRporting = typeOfRporting_voc[randObj.Next(count_typeOfRporting_voc)];
                         NumberOfHoursOfLectures = randObj.Next(1, 100);
                         NumberOfHoursOfPractice = randObj.Next(1, 100);
                         TeacherID = randObj.Next(1, teacher_number - 1);
                         TypeOfDisciplineID = randObj.Next(1, typeOfDiscipline_number - 1);
                         SpecialtyID = randObj.Next(1, specialty_number - 1);
                         context.Disciplins.Add(
                         new Discipline()
                         {
                             NameDiscipline = NameDiscipline,
                             TypeOfRporting = TypeOfRporting,
                             NumberOfHoursOfLectures = NumberOfHoursOfLectures,
                             NumberOfHoursOfPractice = NumberOfHoursOfPractice,
                             TeacherID = TeacherID,
                             TypeOfDisciplineID = TypeOfDisciplineID,
                             SpecialtyID = SpecialtyID
                         });
             }
                    context.SaveChanges();

        }
    }
}
