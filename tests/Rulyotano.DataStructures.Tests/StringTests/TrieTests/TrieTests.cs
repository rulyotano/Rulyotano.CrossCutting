using System;
using Rulyotano.DataStructures.Strings.Trie;
using Xunit;

namespace Rulyotano.DataStructures.Tests;

public class TrieTests
{
    [Fact]
    public void When_AddNewValueAndGetting_Should_ReturnValue()
    {
        var trie = GetTrie();
        const string key = "abc";
        const string value = "a";
        trie.Add(key, GetCollisionResolver(value), GetNewCreator(value));

        var result = trie.Get(key);
        Assert.Equal(value, result);
    }

    [Fact]
    public void When_AddNewValueAndGettingNode_Should_ReturnTrieNode()
    {
        var trie = GetTrie();
        const string key = "abc";
        const string value = "a";
        trie.Add(key, GetCollisionResolver(value), GetNewCreator(value));

        var result = trie.GetNode(key);
        Assert.Equal(value, result.Value);
    }

    [Fact]
    public void When_AddNullOrEmpty_Should_NotRaiseErrorAndReturnNull()
    {
        var trie = GetTrie();
        const string value = "a";
        trie.Add(null, GetCollisionResolver(value), GetNewCreator(value));

        var result = trie.GetNode(null);
        Assert.Null(result);

        trie.Add(string.Empty, GetCollisionResolver(value), GetNewCreator(value));
        result = trie.GetNode(string.Empty);
        Assert.Null(result);
    }

    [Fact]
    public void When_GettingNotExistingNode_Should_ReturnNull()
    {
        var trie = GetTrie();
        const string key = "abc";
        const string value = "a";
        trie.Add(key, GetCollisionResolver(value), GetNewCreator(value));

        var result = trie.GetNode("not-existing-key");
        Assert.Null(result);
    }

    [Fact]
    public void When_GettingNotExistingValue_Should_ReturnNull()
    {
        var trie = GetTrie();
        const string key = "abc";
        const string value = "a";
        trie.Add(key, GetCollisionResolver(value), GetNewCreator(value));

        var result = trie.Get("not-existing-key");
        Assert.Null(result);
    }

    [Fact]
    public void When_GettingIntermediateNodeValue_Should_ReturnNull()
    {
        var trie = GetTrie();
        const string key = "abc";
        const string value = "a";
        trie.Add(key, GetCollisionResolver(value), GetNewCreator(value));

        var result = trie.Get("ab");
        Assert.Null(result);
    }

    [Fact]
    public void Should_InsertAndRetrieveCorrectlySeveralValues()
    {
        var trie = GetTrie();
        const string key = "abc";
        const string value1 = "a";
        const string value2 = "b";
        const string value3 = "c";
        trie.Add(key, GetCollisionResolver(value1), GetNewCreator(value1));
        trie.Add(key, GetCollisionResolver(value2), GetNewCreator(value2));
        trie.Add(key, GetCollisionResolver(value3), GetNewCreator(value3));

        var result = trie.Get(key);
        Assert.Equal("a,b,c", result);
    }

    [Fact]
    public void Should_InsertAndRetrieveCorrectlySeveralValuesFromSeveralKeys()
    {
        var trie = GetTrie();
        const string key1 = "abc";
        const string key2 = "abcde";
        const string value1 = "a";
        const string value2 = "b";
        const string value3 = "c";
        trie.Add(key1, GetCollisionResolver(value1), GetNewCreator(value1));
        trie.Add(key2, GetCollisionResolver(value2), GetNewCreator(value2));
        trie.Add(key1, GetCollisionResolver(value3), GetNewCreator(value3));

        var result = trie.Get(key1);
        Assert.Equal("a,c", result);
        result = trie.Get(key2);
        Assert.Equal("b", result);
    }

    [Fact]
    public void When_AddingValueInsideAlreadyExistingPath_Should_InsertAndRetrieveCorrectly()
    {
        var trie = GetTrie();
        const string fullKey = "abcde";
        const string newKey = "abc";
        const string value1 = "a";
        const string value2 = "b";
        trie.Add(fullKey, GetCollisionResolver(value1), GetNewCreator(value1));
        trie.Add(newKey, GetCollisionResolver(value2), GetNewCreator(value2));

        var result = trie.Get(fullKey);
        Assert.Equal("a", result);
        result = trie.Get(newKey);
        Assert.Equal("b", result);
        result = trie.Get("abcd");
        Assert.Null(result);
    }

    [Fact]
    public void When_AddingValueExtendingAlreadyExistingPath_Should_InsertAndRetrieveCorrectly()
    {
        var trie = GetTrie();
        const string oldSmallKey = "abc";
        const string newKey = "abcde";
        const string value1 = "a";
        const string value2 = "b";
        trie.Add(oldSmallKey, GetCollisionResolver(value2), GetNewCreator(value2));
        trie.Add(newKey, GetCollisionResolver(value1), GetNewCreator(value1));

        var result = trie.Get(oldSmallKey);
        Assert.Equal("b", result);
        result = trie.Get(newKey);
        Assert.Equal("a", result);
        result = trie.Get("abcd");
        Assert.Null(result);
    }

    [Fact]
    public void ValueNode_Should_BeMatchAndLeaf()
    {
        var trie = GetTrie();
        const string key = "abcd";
        const string value = "aaa";
        trie.Add(key, GetCollisionResolver(value), GetNewCreator(value));

        var result = trie.GetNode(key);
        Assert.Equal(value, result.Value);
        Assert.True(result.IsMatch);
        Assert.True(result.IsLeaf);
    }

    [Fact]
    public void MiddleNodeWithNoValue_Should_NotBeMatchNorLeaf()
    {
        var trie = GetTrie();
        const string key = "abcd";
        const string middleKey = "abc";
        const string value = "aaa";
        trie.Add(key, GetCollisionResolver(value), GetNewCreator(value));
        
        var result = trie.GetNode(middleKey);
        Assert.False(result.IsMatch);
        Assert.False(result.IsLeaf);
    }

    [Fact]
    public void MiddleNodeWithValue_Should_BeMatchButNoLeaf()
    {
        var trie = GetTrie();
        const string key = "abcd";
        const string middleKey = "ab";
        const string value = "aaa";
        trie.Add(key, GetCollisionResolver(value), GetNewCreator(value));
        
        trie.Add(middleKey, GetCollisionResolver(value), GetNewCreator(value));
        var middleKeyNode = trie.GetNode(middleKey);
        Assert.True(middleKeyNode.IsMatch);
        Assert.False(middleKeyNode.IsLeaf);
    }

    private Trie<string> GetTrie() => new();

    private Func<string, string> GetCollisionResolver(string value)
        => (string oldValue) => $"{oldValue},{value}";

    private Func<string> GetNewCreator(string value)
        => () => value;

}