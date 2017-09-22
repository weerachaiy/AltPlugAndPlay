﻿// <auto-generated />
using AltPlugAndPlay.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AltPlugAndPlay.Migrations
{
    [DbContext(typeof(PnPServerContext))]
    [Migration("20170921193214_NetworkLinkUpdate")]
    partial class NetworkLinkUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AltPlugAndPlay.Models.NetworkDevice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid?>("DeviceTypeId");

                    b.Property<string>("DomainName");

                    b.Property<string>("Hostname");

                    b.Property<string>("IPAddress");

                    b.HasKey("Id");

                    b.HasIndex("DeviceTypeId");

                    b.ToTable("NetworkDevices");
                });

            modelBuilder.Entity("AltPlugAndPlay.Models.NetworkDeviceLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ConnectedToDeviceId");

                    b.Property<int>("ConnectedToInterfaceIndex");

                    b.Property<int>("InterfaceIndex");

                    b.Property<Guid?>("NetworkDeviceId");

                    b.HasKey("Id");

                    b.HasIndex("ConnectedToDeviceId");

                    b.HasIndex("NetworkDeviceId");

                    b.ToTable("NetworkDeviceLinks");
                });

            modelBuilder.Entity("AltPlugAndPlay.Models.NetworkDeviceType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Name");

                    b.Property<string>("ProductId");

                    b.HasKey("Id");

                    b.ToTable("NetworkDeviceTypes");
                });

            modelBuilder.Entity("AltPlugAndPlay.Models.NetworkInterface", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("DeviceTypeId");

                    b.Property<int>("InterfaceIndex");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DeviceTypeId");

                    b.ToTable("NetworkInterfaces");
                });

            modelBuilder.Entity("AltPlugAndPlay.Models.Template", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("AltPlugAndPlay.Models.TemplateConfiguration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid?>("NetworkDeviceId");

                    b.Property<Guid?>("TemplateId");

                    b.HasKey("Id");

                    b.HasIndex("NetworkDeviceId");

                    b.HasIndex("TemplateId");

                    b.ToTable("TemplateConfigurations");
                });

            modelBuilder.Entity("AltPlugAndPlay.Models.TemplateProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("TemplateConfigurationId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("TemplateConfigurationId");

                    b.ToTable("TemplateProperties");
                });

            modelBuilder.Entity("AltPlugAndPlay.Models.NetworkDevice", b =>
                {
                    b.HasOne("AltPlugAndPlay.Models.NetworkDeviceType", "DeviceType")
                        .WithMany()
                        .HasForeignKey("DeviceTypeId");
                });

            modelBuilder.Entity("AltPlugAndPlay.Models.NetworkDeviceLink", b =>
                {
                    b.HasOne("AltPlugAndPlay.Models.NetworkDevice", "ConnectedToDevice")
                        .WithMany()
                        .HasForeignKey("ConnectedToDeviceId");

                    b.HasOne("AltPlugAndPlay.Models.NetworkDevice", "NetworkDevice")
                        .WithMany("Uplinks")
                        .HasForeignKey("NetworkDeviceId");
                });

            modelBuilder.Entity("AltPlugAndPlay.Models.NetworkInterface", b =>
                {
                    b.HasOne("AltPlugAndPlay.Models.NetworkDeviceType", "DeviceType")
                        .WithMany("Interfaces")
                        .HasForeignKey("DeviceTypeId");
                });

            modelBuilder.Entity("AltPlugAndPlay.Models.TemplateConfiguration", b =>
                {
                    b.HasOne("AltPlugAndPlay.Models.NetworkDevice", "NetworkDevice")
                        .WithMany()
                        .HasForeignKey("NetworkDeviceId");

                    b.HasOne("AltPlugAndPlay.Models.Template", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateId");
                });

            modelBuilder.Entity("AltPlugAndPlay.Models.TemplateProperty", b =>
                {
                    b.HasOne("AltPlugAndPlay.Models.TemplateConfiguration", "TemplateConfiguration")
                        .WithMany("Properties")
                        .HasForeignKey("TemplateConfigurationId");
                });
#pragma warning restore 612, 618
        }
    }
}