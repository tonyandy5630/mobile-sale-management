using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MobileSaleLibrary.Models;

namespace MobileSaleLibrary.DataAccess
{
    public partial class SalePhoneMangementContext : DbContext
    {
        public SalePhoneMangementContext()
        {
        }

        public SalePhoneMangementContext(DbContextOptions<SalePhoneMangementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> TblCustomers { get; set; }
        public virtual DbSet<Import> TblImports { get; set; }
        public virtual DbSet<ImportInfo> TblImportInfos { get; set; }
        public virtual DbSet<Model> TblModels { get; set; }
        public virtual DbSet<Phone> TblPhones { get; set; }
        public virtual DbSet<Receipt> TblReceipts { get; set; }
        public virtual DbSet<ReceiptInfo> TblReceiptInfos { get; set; }
        public virtual DbSet<Supplier> TblSuppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =(local); database = SalePhoneMangement;uid=sa;pwd=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("tblCustomer");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(200)
                    .HasColumnName("customerAddress");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .HasColumnName("customerName");

                entity.Property(e => e.CustomerPhoneNumber)
                    .HasMaxLength(10)
                    .HasColumnName("customerPhoneNumber")
                    .IsFixedLength();

                entity.Property(e => e.Gender).HasMaxLength(10);
            });

            modelBuilder.Entity<Import>(entity =>
            {
                entity.HasKey(e => e.ImportId);

                entity.ToTable("tblImport");

                entity.Property(e => e.ImportId).HasColumnName("importID");

                entity.Property(e => e.ImportDate)
                    .HasColumnType("date")
                    .HasColumnName("importDate");

                entity.Property(e => e.SupplierId).HasColumnName("supplierID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblImports)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_tblImport_tblSupplier");
            });

            modelBuilder.Entity<ImportInfo>(entity =>
            {
                entity.HasKey(e => new { e.ImportId, e.PhoneId })
                    .HasName("PK_ImportInfo");

                entity.ToTable("tblImportInfo");

                entity.Property(e => e.ImportId).HasColumnName("importID");

                entity.Property(e => e.PhoneId).HasColumnName("phoneID");

                entity.Property(e => e.BuyPricePerUnit).HasColumnName("buyPricePerUnit");

                entity.HasOne(d => d.Import)
                    .WithMany(p => p.TblImportInfos)
                    .HasForeignKey(d => d.ImportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblImportInfo_tblImport");

                entity.HasOne(d => d.Phone)
                    .WithMany(p => p.TblImportInfos)
                    .HasForeignKey(d => d.PhoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblImportInfo_tblPhone");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.ModelId)
                    .HasName("PK_tblPhoneInfo");

                entity.ToTable("tblModel");

                entity.Property(e => e.ModelId).HasColumnName("modelID");

                entity.Property(e => e.ModelBrand)
                    .HasMaxLength(10)
                    .HasColumnName("modelBrand");

                entity.Property(e => e.ModelName)
                    .HasMaxLength(50)
                    .HasColumnName("modelName");

                entity.Property(e => e.ModelOrigin)
                    .HasMaxLength(10)
                    .HasColumnName("modelOrigin");

                entity.Property(e => e.ModelYearOfWarranty).HasColumnName("modelYearOfWarranty");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasKey(e => e.PhoneId)
                    .HasName("PK_Phone");

                entity.ToTable("tblPhone");

                entity.Property(e => e.PhoneId).HasColumnName("phoneID");

                entity.Property(e => e.ModelId).HasColumnName("modelID");

                entity.Property(e => e.ShowPrice).HasColumnName("showPrice");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("type");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.TblPhones)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPhone_tblModel");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasKey(e => e.ReceiptId);

                entity.ToTable("tblReceipt");

                entity.Property(e => e.ReceiptId).HasColumnName("receiptID");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.ReceiptDate)
                    .HasColumnType("date")
                    .HasColumnName("receiptDate");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TblReceipts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblReceipt_tblCustomer");
            });

            modelBuilder.Entity<ReceiptInfo>(entity =>
            {
                entity.HasKey(e => new { e.ReceiptId, e.PhoneId });

                entity.ToTable("tblReceiptInfo");

                entity.Property(e => e.ReceiptId).HasColumnName("receiptID");

                entity.Property(e => e.PhoneId).HasColumnName("phoneID");

                entity.Property(e => e.SellPricePerUnit)
                    .HasMaxLength(10)
                    .HasColumnName("sellPricePerUnit")
                    .IsFixedLength();

                entity.HasOne(d => d.Phone)
                    .WithMany(p => p.TblReceiptInfos)
                    .HasForeignKey(d => d.PhoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblReceiptInfo_tblPhone");

                entity.HasOne(d => d.Receipt)
                    .WithMany(p => p.TblReceiptInfos)
                    .HasForeignKey(d => d.ReceiptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblReceiptInfo_tblReceipt");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.ToTable("tblSupplier");

                entity.Property(e => e.SupplierId).HasColumnName("supplierID");

                entity.Property(e => e.SupplierAddress)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("supplierAddress");

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("supplierName");

                entity.Property(e => e.SupplierPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("supplierPhoneNumber");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
