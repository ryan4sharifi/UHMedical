using System;
using System.Collections.Generic;
using Medical.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Medical.Data
{
    public partial class team12Context : DbContext
    {
        public team12Context()
        {
        }

        public team12Context(DbContextOptions<team12Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<AppointmentSv> AppointmentSvs { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<DoctorDetail> DoctorDetails { get; set; } = null!;
        public virtual DbSet<DoctorList> DoctorLists { get; set; } = null!;
        public virtual DbSet<EmergencyContact> EmergencyContacts { get; set; } = null!;
        public virtual DbSet<Insurance> Insurances { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<MedicalHistory> MedicalHistories { get; set; } = null!;
        public virtual DbSet<MetaData> MetaDatas { get; set; } = null!;
        public virtual DbSet<Nurse> Nurses { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Prescription> Prescriptions { get; set; } = null!;
        public virtual DbSet<Referral> Referrals { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<Speciality> Specialities { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:mcteam12.database.windows.net,1433;Initial Catalog=team12;Persist Security Info=False;User ID=team12;Password=UHMedical@12;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdminId).HasColumnName("admin_id");

                entity.Property(e => e.DoB).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleInitial)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("middle_initial");

                entity.Property(e => e.Office)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("office");

                entity.Property(e => e.Phone)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");

                entity.Property(e => e.DateAppointment)
                    .HasColumnType("datetime")
                    .HasColumnName("date_appointment");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__docto__2D47B39A");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__patie__2E3BD7D3");
            });

            modelBuilder.Entity<AppointmentSv>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Appointment_SV");

                entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");

                entity.Property(e => e.DateAppointment)
                    .HasColumnType("datetime")
                    .HasColumnName("date_appointment");

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(152)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .HasMaxLength(152)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.DoB).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleInitial)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("middle_initial");

                entity.Property(e => e.Office)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("office");

                entity.Property(e => e.Phone)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.SpecialtyId).HasColumnName("specialty_id");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.SpecialtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Doctors__special__4CC05EF3");
            });
            modelBuilder.Entity<Doctor>()
                    .HasOne(d => d.User)
                    .WithOne()
                    .HasForeignKey<Doctor>(d => d.UserId)
                    .IsRequired();


            modelBuilder.Entity<DoctorDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Doctor_Details");

                entity.Property(e => e.Classification)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("classification");

                entity.Property(e => e.DoB).HasColumnType("date");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleInitial)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("middle_initial");

                entity.Property(e => e.Office)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("office");

                entity.Property(e => e.Phone)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<DoctorList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Doctor_List");

                entity.Property(e => e.Classification)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("classification");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(152)
                    .IsUnicode(false);

                entity.Property(e => e.Office)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmergencyContact>(entity =>
            {
                entity.Property(e => e.EmergencyContactId).HasColumnName("emergency_contact_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleInitial)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("middle_initial");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.Phone)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Relation)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("relation");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.EmergencyContacts)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Emergency__patie__3118447E");
            });

            modelBuilder.Entity<Insurance>(entity =>
            {
                entity.Property(e => e.InsuranceId).HasColumnName("insurance_id");

                entity.Property(e => e.InsuranceName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("insurance_name");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Insurances)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Insurance__patie__22CA2527");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("balance");

                entity.Property(e => e.Copay)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("copay");

                entity.Property(e => e.DueDate)
                    .HasColumnType("date")
                    .HasColumnName("due_date");

                entity.Property(e => e.InsuranceDeduction)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("insurance_deduction");

                entity.Property(e => e.InsuranceId).HasColumnName("insurance_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.HasOne(d => d.Insurance)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.InsuranceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invoices__insura__34E8D562");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invoices__patien__33F4B129");
            });

            modelBuilder.Entity<MedicalHistory>(entity =>
            {
                entity.Property(e => e.MedicalHistoryId).HasColumnName("medical_history_id");

                entity.Property(e => e.Allergies)
                    .HasColumnType("text")
                    .HasColumnName("allergies");

                entity.Property(e => e.DiagnosisInfo)
                    .HasColumnType("text")
                    .HasColumnName("diagnosis_info");

                entity.Property(e => e.Medication)
                    .HasColumnType("text")
                    .HasColumnName("medication");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.Surgeries)
                    .HasColumnType("text")
                    .HasColumnName("surgeries");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.MedicalHistories)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MedicalHi__patie__37C5420D");
            });

            modelBuilder.Entity<MetaData>(entity =>
            {
                entity.Property(e => e.MetaDataId).HasColumnName("meta_data_id");

                entity.Property(e => e.Changelog)
                    .HasColumnType("text")
                    .HasColumnName("changelog");

                entity.Property(e => e.IdentifierNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("identifier_number");

                entity.Property(e => e.LoginInfo)
                    .HasColumnType("text")
                    .HasColumnName("login_info");
            });

            modelBuilder.Entity<Nurse>(entity =>
            {
                entity.Property(e => e.NurseId).HasColumnName("nurse_id");

                entity.Property(e => e.DoB).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleInitial)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("middle_initial");

                entity.Property(e => e.Office)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("office");

                entity.Property(e => e.Phone)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("balance");

                entity.Property(e => e.DoB).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("gender")
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleInitial)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("middle_initial");

                entity.Property(e => e.Phone)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.Property(e => e.PrescriptionId).HasColumnName("prescription_id");

                entity.Property(e => e.DatePrescription)
                    .HasColumnType("date")
                    .HasColumnName("date_prescription");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.Dosage)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("dosage");

                entity.Property(e => e.DrugName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("drug_name");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.Refills).HasColumnName("refills");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prescript__docto__3AA1AEB8");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prescript__patie__3B95D2F1");
            });

            modelBuilder.Entity<Referral>(entity =>
            {
                entity.Property(e => e.ReferralId).HasColumnName("referral_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.PrimaryDoctorId).HasColumnName("primary_doctor_id");

                entity.Property(e => e.ReferralDate)
                    .HasColumnType("date")
                    .HasColumnName("referral_date");

                entity.Property(e => e.SpecialistDoctorId).HasColumnName("specialist_doctor_id");

                entity.Property(e => e.SpecialtyId).HasColumnName("specialty_id");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Referrals)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Referrals__patie__405A880E");

                entity.HasOne(d => d.PrimaryDoctor)
                    .WithMany(p => p.ReferralPrimaryDoctors)
                    .HasForeignKey(d => d.PrimaryDoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Referrals__prima__3E723F9C");

                entity.HasOne(d => d.SpecialistDoctor)
                    .WithMany(p => p.ReferralSpecialistDoctors)
                    .HasForeignKey(d => d.SpecialistDoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Referrals__speci__3F6663D5");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.Referrals)
                    .HasForeignKey(d => d.SpecialtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Referrals__speci__4BCC3ABA");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");

                entity.Property(e => e.DateSchedule)
                    .HasColumnType("date")
                    .HasColumnName("date_schedule");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.EndTime).HasColumnName("end_time");

                entity.Property(e => e.StartTime).HasColumnName("start_time");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedules__docto__442B18F2");
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.Property(e => e.SpecialityId).HasColumnName("speciality_id");

                entity.Property(e => e.Classification)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("classification");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.Property(e => e.TestId).HasColumnName("test_id");

                entity.Property(e => e.DateTest)
                    .HasColumnType("date")
                    .HasColumnName("date_test");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.Results)
                    .HasColumnType("text")
                    .HasColumnName("results");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tests__doctor_id__4707859D");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tests__patient_i__47FBA9D6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
