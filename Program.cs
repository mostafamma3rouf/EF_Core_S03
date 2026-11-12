using EF_Core_S03.AppDbContexts;
using EF_Core_S03.Models;
using EF_Core_S03.Seed;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_S03
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using LearningPlatformDbContext DbContext = new LearningPlatformDbContext();

            #region Seeding

            //SeedData.SeedStudents(DbContext);
            //SeedData.SeedEnrollments(DbContext);

            #endregion

            #region Create
            #region Add an instructor
            //Instructors instructor = new Instructors
            //{
            //    FullName = "John Doe",
            //    Email = "john.doe@example.com",
            //    JoinedDate = DateTime.Now
            //};

            //DbContext.Instructors.Add(instructor);
            //await DbContext.SaveChangesAsync();

            //// Print the generated Id
            //Console.WriteLine($"Generated Id: {instructor.Id}");

            #endregion

            #region Add a course
            //Courses Cousre = new Courses()
            //{
            //    Title = "Angular Basics",
            //    Price = 59.99m,
            //    level = Level.Beginner,
            //    InstructorId = 1,
            //    CategoryId = 1
            //};

            //if (!DbContext.Instructors.Any(I => I.Id == Cousre.InstructorId) || !DbContext.Categories.Any(C => C.Id == Cousre.CategoryId))
            //{
            //    Console.WriteLine("The instructor or the category does not exist.");
            //    return;
            //}

            //DbContext.Courses.Add(Cousre);
            //await DbContext.SaveChangesAsync();

            #endregion

            #region Add several students
            //var students = new List<Students>
            //{
            //    new Students { FullName = "Sara Ahmed",  Email = "sara.ahmed@mail.com",  DateOfBirth = new DateTime(2001, 4, 12) },
            //    new Students { FullName = "Omar Hassan", Email = "omar.hassan@mail.com", DateOfBirth = new DateTime(2000, 9, 30) },
            //    new Students { FullName = "Fatma Ali",   Email = "fatma.ali@mail.com",   DateOfBirth = new DateTime(2002, 12, 5) }
            //};

            //DbContext.Students.AddRange(students);
            //await DbContext.SaveChangesAsync();

            //foreach (var student in students)
            //{
            //    Console.WriteLine($"Generated Id: {student.Id} => {student.FullName}");
            //}

            #endregion

            #region Enroll a student

            #endregion

            #endregion

            #region Read
            #region Find a course
            //// Get a course by Id using Find
            //var GetACourseById = await DbContext.Courses.FindAsync(1);

            //if (GetACourseById == null)
            //{
            //    Console.WriteLine("not found");
            //}

            //// by title using FirstOrDefault
            //var GetACourseByTitle = await DbContext.Courses.FirstOrDefaultAsync(C => C.Title == "C# Fundamentals");

            //if (GetACourseByTitle == null)
            //{
            //    Console.WriteLine("not found");
            //}
            #endregion

            #region Filter courses
            //var FilteredCourses = DbContext.Courses.Where(C => C.Price > 40 && C.Price < 100)
            //                                       .OrderByDescending(C => C.Price)
            //                                       .ToList();

            //foreach(var course in FilteredCourses)
            //    Console.WriteLine($"Course: {course.Title}, Level: {course.level}, Price: {course.Price}");
            #endregion

            #region Sub-categories
            // Print the direct sub-categories of a given category
            //var SubCategories = DbContext.Categories.Where(SC => SC.ParentCategoryId == 1)
            //                                        .ToList();

            //foreach (var subCategory in SubCategories)
            //    Console.WriteLine($"Id: {subCategory.Id} ,Sub-category: {subCategory.CategoryName}");

            // print the top-level categories.
            //var TopLevelCategories = DbContext.Categories.Where(C => C.ParentCategoryId == null)
            //                                             .ToList();

            //foreach (var category in TopLevelCategories)
            //    Console.WriteLine($"Id: {category.Id} ,Category: {category.CategoryName}");

            #endregion

            #region Course roster
            //// get the student Ids from the enrollments
            //var EnrolledStudentIds = DbContext.Enrollments.Where(E => E.CourseId == 2)
            //                                              .Select(E => E.StudentId)
            //                                              .ToList();

            //// get the students with Contains
            //var EnrolledStudents = DbContext.Students.Where(S => EnrolledStudentIds.Contains(S.Id))
            //                                         .ToList();

            //// Print how many students are enrolled in a course
            //Console.WriteLine($"Students enrolled in course: {EnrolledStudentIds.Count}");

            //foreach (var student in EnrolledStudents)
            //    Console.WriteLine($"Id: {student.Id} ,Student: {student.FullName}");
            #endregion
            #endregion

            #region Update
            #region Change a price
            //var loadedCourse = await DbContext.Courses.FindAsync(1);

            //if (loadedCourse != null)
            //{
            //    loadedCourse.Price = 59.99m;
            //    await DbContext.SaveChangesAsync();
            //}
            //else
            //{
            //    Console.WriteLine("Course not found");
            //}

            #endregion

            #region Update progress
            //int ProgressStudentId = 1;
            //int ProgressCourseId = 1;
            //decimal NewProgress = 100m;

            //var FoundEnrollment = DbContext.Enrollments.Find(ProgressStudentId, ProgressCourseId);

            //if (FoundEnrollment == null)
            //{
            //    Console.WriteLine("Enrollment not found");
            //}
            //else if (NewProgress < 0 || NewProgress > 100)
            //{
            //    Console.WriteLine("Progress rejected: the value must be between 0 and 100.");
            //}
            //else
            //{
            //    FoundEnrollment.ProgressPercentage = NewProgress;

            //    if (NewProgress == 100)
            //        FoundEnrollment.Status = EnrollmentStatus.Completed;

            //    DbContext.SaveChanges();
            //}
            #endregion

            #region Publish a course
            //int PublishCourseId = 4;

            //var CourseToPublish = DbContext.Courses.Find(PublishCourseId);

            //if (CourseToPublish == null)
            //{
            //    Console.WriteLine("Course not found");
            //}
            //else
            //{
            //    CourseToPublish.IsPublished = true;
            //    CourseToPublish.PublishedDate = DateTime.UtcNow;

            //    DbContext.SaveChanges();

            //}
            #endregion
            #endregion

            #region Delete
            #region Unenroll
            //int StudentId = 1;
            //int CourseId = 1;

            //var EnrollmentToDelete = await DbContext.Enrollments.FindAsync(StudentId, CourseId);

            //if (EnrollmentToDelete != null)
            //{
            //    DbContext.Enrollments.Remove(EnrollmentToDelete);
            //    await DbContext.SaveChangesAsync();
            //}
            //else
            //{
            //    Console.WriteLine("Enrollment not found");
            //}
            #endregion

            #region Delete a category
            //// Unsafe deletion of a category
            //int UnsafeCategoryId = 1;

            //var CategoryWithSubCategories = await DbContext.Categories.FindAsync(UnsafeCategoryId);
            //if (CategoryWithSubCategories != null)
            //{
            //    try
            //    {
            //        DbContext.Categories.Remove(CategoryWithSubCategories);
            //        DbContext.SaveChanges();
            //    }
            //    catch(DbUpdateException dbEx)
            //    {
            //        Console.WriteLine($"Error deleting category: {dbEx.Message}");
            //    }

            //}
            //else
            //{
            //    Console.WriteLine("Category not found");
            //}

            //// Safe deletion of a category
            //int SafeCategoryId = 1;

            //var categoryToDelete = DbContext.Categories.Find(SafeCategoryId);

            //if (categoryToDelete == null)
            //{
            //    Console.WriteLine("Category not found");
            //}
            //else if (DbContext.Categories.Any(c => c.ParentCategoryId == SafeCategoryId))
            //{
            //    Console.WriteLine($"Cannot delete '{categoryToDelete.CategoryName}': it still has sub-categories.");
            //}
            //else
            //{
            //    DbContext.Categories.Remove(categoryToDelete);
            //    DbContext.SaveChanges();

            //    Console.WriteLine($"Category '{categoryToDelete.CategoryName}' was deleted.");
            //}
            #endregion

            #region Delete a course
            //int CourseToRemoveId = 3;

            //var CourseToRemove = DbContext.Courses.Find(CourseToRemoveId);
            //if (CourseToRemove == null)
            //{
            //    Console.WriteLine("Course not found");
            //}
            //else
            //{
            //    int EnrollmentsBefore = DbContext.Enrollments.Count(E => E.CourseId == CourseToRemoveId);
            //    Console.WriteLine($"Enrollments of course {CourseToRemoveId} before: {EnrollmentsBefore}");

            //    DbContext.Courses.Remove(CourseToRemove);
            //    DbContext.SaveChanges();

            //    int EnrollmentsAfter = DbContext.Enrollments.Count(E => E.CourseId == CourseToRemoveId);
            //    Console.WriteLine($"Enrollments of course {CourseToRemoveId} after: {EnrollmentsAfter}");
            //}
            #endregion
            #endregion

            #region Bulk operations
            #region Bulk price raise
            //Level RaiseLevel = Level.Beginner;

            //int RaisedRows = DbContext.Courses.Where(C => C.IsPublished && C.level == RaiseLevel)
            //                                  .ExecuteUpdate(Setters => Setters.SetProperty(C => C.Price, C => C.Price * 1.10m));

            //Console.WriteLine($"Affected rows: {RaisedRows}");
            #endregion

            #region Bulk delete
            //int DeletedDroppedRows = DbContext.Enrollments.Where(E => E.Status == EnrollmentStatus.Dropped)
            //                                              .ExecuteDelete();

            //Console.WriteLine($"Affected rows: {DeletedDroppedRows}");
            #endregion
            #endregion
        }
    }
}
