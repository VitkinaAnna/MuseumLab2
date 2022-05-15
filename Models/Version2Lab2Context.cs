using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Lab2MuseumVersion2.Models;

namespace Lab2MuseumVersion2.Models
{
    public class Version2Lab2Context : DbContext
    {

        public virtual DbSet<Dinosaur> Dinosaurs { get; set; } = null!;
        public virtual DbSet<Exhibition> Exhibitions { get; set; } = null!;
        public virtual DbSet<Hall> Halls { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;

        public Version2Lab2Context(DbContextOptions<Version2Lab2Context> options)
           : base(options)
        {
            Database.EnsureCreated();
        }

    }
}