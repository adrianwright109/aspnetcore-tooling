﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Xunit;

namespace Microsoft.AspNetCore.Razor.LanguageServer.Formatting
{
    public class CodeDirectiveOnTypeFormattingTest : FormattingTestBase
    {
        [Fact]
        public async Task CloseCurly_Class_SingleLine()
        {
            await RunOnTypeFormattingTestAsync(
input: @"
@code {
 public class Foo{$$}
}
",
expected: @"
@code {
    public class Foo { }
}
",
triggerCharacter: "}");
        }

        [Fact]
        public async Task CloseCurly_Class_MultiLine()
        {
            await RunOnTypeFormattingTestAsync(
input: @"
@code {
 public class Foo{
$$}
}
",
expected: @"
@code {
    public class Foo
    {
    }
}
",
triggerCharacter: "}");
        }

        [Fact]
        public async Task CloseCurly_Method_SingleLine()
        {
            await RunOnTypeFormattingTestAsync(
input: @"
@code {
 public void Foo{$$}
}
",
expected: @"
@code {
    public void Foo { }
}
",
triggerCharacter: "}");
        }

        [Fact]
        public async Task CloseCurly_Method_MultiLine()
        {
            await RunOnTypeFormattingTestAsync(
input: @"
@code {
 public void Foo{
$$}
}
",
expected: @"
@code {
    public void Foo
    {
    }
}
",
triggerCharacter: "}");
        }

        [Fact]
        public async Task CloseCurly_Property_SingleLine()
        {
            await RunOnTypeFormattingTestAsync(
input: @"
@code {
 public string Foo{ get;set;$$}
}
",
expected: @"
@code {
    public string Foo { get; set; }
}
",
triggerCharacter: "}");
        }

        [Fact]
        public async Task CloseCurly_Property_MultiLine()
        {
            await RunOnTypeFormattingTestAsync(
input: @"
@code {
 public string Foo{
get;set;$$}
}
",
expected: @"
@code {
    public string Foo
    {
        get; set;
    }
}
",
triggerCharacter: "}");
        }

        [Fact]
        public async Task CloseCurly_Property_StartOfBlock()
        {
            await RunOnTypeFormattingTestAsync(
input: @"
@code { public string Foo{ get;set;$$}
}
",
expected: @"
@code {
    public string Foo { get; set; }
}
",
triggerCharacter: "}");
        }

        [Fact]
        public async Task Semicolon_ClassField_SingleLine()
        {
            await RunOnTypeFormattingTestAsync(
input: @"
@code {
 public class Foo{private int _hello = 0$$;}
}
",
expected: @"
@code {
    public class Foo { private int _hello = 0; }
}
",
triggerCharacter: ";");
        }

        [Fact]
        public async Task Semicolon_ClassField_MultiLine()
        {
            await RunOnTypeFormattingTestAsync(
input: @"
@code {
    public class Foo{
private int _hello = 0$$; }
}
",
expected: @"
@code {
    public class Foo{
        private int _hello = 0; }
}
",
triggerCharacter: ";");
        }

        [Fact]
        public async Task Semicolon_MethodVariable()
        {
            await RunOnTypeFormattingTestAsync(
input: @"
@code {
    public void Foo()
    {
                            var hello = 0$$;
    }
}
",
expected: @"
@code {
    public void Foo()
    {
        var hello = 0;
    }
}
",
triggerCharacter: ";");
        }

        [Fact]
        public async Task Newline_BraceIndent()
        {
            await RunOnTypeFormattingTestAsync(
input: @"
@code {
    public class Foo {$$
}
}
",
expected: @"
@code {
    public class Foo
    {
    }
}
",
triggerCharacter: @"
"); // Newline
        }
    }
}
