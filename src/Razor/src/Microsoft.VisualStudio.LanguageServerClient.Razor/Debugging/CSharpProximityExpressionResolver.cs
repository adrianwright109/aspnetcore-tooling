﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading;
using Microsoft.CodeAnalysis;

namespace Microsoft.VisualStudio.LanguageServerClient.Razor.Debugging
{
    internal abstract class CSharpProximityExpressionResolver
    {
        public abstract IReadOnlyList<string> GetProximityExpressions(SyntaxTree syntaxTree, int absoluteIndex, CancellationToken cancellationToken);
    }
}
