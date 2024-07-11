// See https://aka.ms/new-console-template for more information
using TestModelMapperLibB01.Config;
using TestModelMapperLibB01.Dto;
using TestModelMapperLibB01.Entities;

StudentDto studentDto = new StudentDto()
{
    Name = "Phucdn",
    Age = 24,
    SignNum = 1.4f
};

// Initializing AutoMapper
var mapper = ModelMapperConfig.InitializeAutoMapper();

var student = mapper.Map<StudentDto, StudentEntity>(studentDto);
// Set up new generate id
Guid newIdGuid = Guid.NewGuid();
student.Id = newIdGuid;
Console.WriteLine("Id: "+student.Id + ", Name:" + student.Name + ", Age:" + student.Age + ", SignNum:" + student.SignNum);
