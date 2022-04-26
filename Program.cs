using RecruitmentEmployee.Data;
using RecruitmentEmployee.Models;
using RecruitmentEmployee.Repositories;
using System;
using System.Collections.Generic;

namespace RecruitmentEmployee
{
    internal class Program
    {
        //static Employee FindByCodeTest(string code, EmployeeRepository repository)
        //{
        //    return repository.FindByCode(code);
        //}
        //static Position GetPositionByCodeTest(string code, PositionRepository repository)
        //{
        //    return repository.GetPositionByCode(code);
        //}
        //static List<AnnualSalary> GetAnnualSalaryByEmployeeCodeTest(string code, AnnualSalaryRepository repository)
        //{
        //    return repository.GetAnnualSalaryByEmployeeCode(code);
        //}
        //static List<MonthlySalary> GetMonthlySalaryByEmployeeCodeTest(string code, MonthlySalaryRepository repository)
        //{
        //    return repository.GetMonthlySalaryByEmployeeCode(code);
        //}
        //static IEnumerable<dynamic> GetEmployeeSkillsByEmployeeCodeTest(string code, EmployeeSkillRepository repository)
        //{
        //    return repository.GetEmployeeSkillsByEmployeeCode(code);
        //}
        static void Main(string[] args)
        {
            ConfigurationHelper configurationHelper = ConfigurationHelper.Instance();
            var dbConnectionString = configurationHelper.GetProperty<string>("DbConnectionString");

            using (RecruitmentContext context = new RecruitmentContext(dbConnectionString))
            {
                try
                {
                    Console.Write("Enter Employee Code: ");
                    string code = Console.ReadLine();

                    EmployeeRepository employeeRepository = new EmployeeRepository(context);
                    Employee existingEmployee = employeeRepository.FindByCode(code);
                    Console.WriteLine($"\nFirst Name: {existingEmployee.VFirstName}");
                    Console.WriteLine($"Last Name: {existingEmployee.VLastName}");
                    Console.WriteLine($"Birth date: {existingEmployee.DBirthDate?.ToString("MMMM dd, yyyy")}");

                    PositionRepository positionRepository = new PositionRepository(context);
                    Position employeePosition = positionRepository.GetPositionByCode(existingEmployee.CCurrentPosition);

                    Console.WriteLine($"Current Position: {employeePosition.VDescription}");

                    AnnualSalaryRepository annualSalaryRepository = new AnnualSalaryRepository(context);
                    List<AnnualSalary> employeeAnnualSalary = annualSalaryRepository.GetAnnualSalaryByEmployeeCode(code);

                    Console.WriteLine("\nAnnual Salary Of Employee ~~");
                    foreach (var annualSalary in employeeAnnualSalary)
                    {
                        Console.WriteLine($"\tYear: {annualSalary.SiYear}, Salary: {annualSalary.MAnnualSalary}");
                    };


                    MonthlySalaryRepository monthlySalaryRepository = new MonthlySalaryRepository(context);
                    List<MonthlySalary> employeeMonthlySalary = monthlySalaryRepository.GetMonthlySalaryByEmployeeCode(code);

                    Console.WriteLine("\nMonthly Salary Of Employee ~~");
                    foreach (var monthlySalary in employeeMonthlySalary)
                    {
                        Console.WriteLine($"\tMonth: {monthlySalary.DPayDate.ToString("MMMM yyyy")}, Salary: {monthlySalary.MMonthlySalary}, Referral Bonus: {monthlySalary.MReferralBonus}");
                    };

                    EmployeeSkillRepository employeeSkillRepository = new EmployeeSkillRepository(context);
                    IEnumerable<dynamic> employeeSkills = employeeSkillRepository.GetEmployeeSkillsByEmployeeCode(code);

                    Console.WriteLine("\nEmployee Skills ~~");
                    foreach (var employeeSkill in employeeSkills)
                    {
                        Console.WriteLine($"\t{employeeSkill.CSkillCode}");
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Found: {ex.Message}");
                }
            }
        }
    }
}
