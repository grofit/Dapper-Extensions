﻿using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;

namespace DapperExtensions.Test.Data.Common
{
    public class CustomMapper : PluralizedAutoClassMapper<Foo>
    {
        public CustomMapper() : base()
        {
            TableName = "FooTable";

            Map(f => f.BarList).Ignore();

            ReferenceMap(f => f.BarList).Reference<Bar>((bar, foo) => bar.FooId == foo.Id);
        }
    }

    public class CustomBarMapper : PluralizedAutoClassMapper<Bar>
    {
        public CustomBarMapper() : base()
        {
            TableName = "Bar";
            Map(f => f.Id).Column("BarId").Key(KeyType.Identity);
            Map(f => f.Name).Column("BarName");
        }
    }

    public class Foo
    {
        public long Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        public IList<Bar> BarList { get; set; }
    }

    public class Bar
    {
        public long Id { get; set; }
        public long FooId { get; set; }
        public string Name { get; set; }
    }
}