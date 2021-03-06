﻿// ==========================================================================
//  Squidex Headless CMS
// ==========================================================================
//  Copyright (c) Squidex UG (haftungsbeschränkt)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using Xunit;

namespace Squidex.Domain.Apps.Core.Model
{
    public sealed class PartitioningTests
    {
        [Fact]
        public void Should_consider_null_as_valid_partitioning()
        {
            string partitioning = null;

            Assert.True(partitioning.IsValidPartitioning());
        }

        [Fact]
        public void Should_consider_invariant_as_valid_partitioning()
        {
            var partitioning = "invariant";

            Assert.True(partitioning.IsValidPartitioning());
        }

        [Fact]
        public void Should_consider_language_as_valid_partitioning()
        {
            var partitioning = "language";

            Assert.True(partitioning.IsValidPartitioning());
        }

        [Fact]
        public void Should_not_consider_empty_as_valid_partitioning()
        {
            var partitioning = string.Empty;

            Assert.False(partitioning.IsValidPartitioning());
        }

        [Fact]
        public void Should_not_consider_other_string_as_valid_partitioning()
        {
            var partitioning = "invalid";

            Assert.False(partitioning.IsValidPartitioning());
        }

        [Fact]
        public void Should_provide_invariant_instance()
        {
            Assert.Equal("invariant", Partitioning.Invariant.Key);
            Assert.Equal("invariant", Partitioning.Invariant.ToString());
        }

        [Fact]
        public void Should_provide_language_instance()
        {
            Assert.Equal("language", Partitioning.Language.Key);
            Assert.Equal("language", Partitioning.Language.ToString());
        }

        [Fact]
        public void Should_make_correct_equal_comparisons()
        {
            var partitioning1a = new Partitioning("partitioning1");
            var partitioning1b = new Partitioning("partitioning1");
            var partitioning2a = new Partitioning("partitioning2");

            Assert.True(partitioning1a.Equals(partitioning1b));

            Assert.False(partitioning1a.Equals(partitioning2a));
        }

        [Fact]
        public void Should_make_correct_object_equal_comparisons()
        {
            object partitioning1a = new Partitioning("partitioning1");
            object partitioning1b = new Partitioning("partitioning1");
            object partitioning2a = new Partitioning("partitioning2");

            Assert.True(partitioning1a.Equals(partitioning1b));

            Assert.False(partitioning1a.Equals(partitioning2a));
        }

        [Fact]
        public void Should_provide_correct_hash_codes()
        {
            var partitioning1a = new Partitioning("partitioning1");
            var partitioning1b = new Partitioning("partitioning1");
            var partitioning2a = new Partitioning("partitioning2");

            Assert.Equal(partitioning1a.GetHashCode(), partitioning1b.GetHashCode());

            Assert.NotEqual(partitioning1a.GetHashCode(), partitioning2a.GetHashCode());
        }
    }
}
