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
        trie.Add(key, value);

        var result = trie.Get(key);
        Assert.Equal(value, result);
    }

    [Fact]
    public void When_AddNewValueAndGettingNode_Should_ReturnTrieNode()
    {
        var trie = GetTrie();
        const string key = "abc";
        const string value = "a";
        trie.Add(key, value);

        var result = trie.GetNode(key);
        Assert.Equal(value, result.Value);
    }

    [Fact]
    public void When_AddNullOrEmpty_Should_NotRaiseErrorAndReturnNull()
    {
        var trie = GetTrie();
        const string value = "a";
        trie.Add(null, value);

        var result = trie.GetNode(null);
        Assert.Null(result);

        trie.Add(string.Empty, value);
        result = trie.GetNode(string.Empty);
        Assert.Null(result);
    }

    [Fact]
    public void When_GettingNotExistingNode_Should_ReturnNull()
    {
        var trie = GetTrie();
        const string key = "abc";
        const string value = "a";
        trie.Add(key, value);

        var result = trie.GetNode("not-existing-key");
        Assert.Null(result);
    }

    [Fact]
    public void When_GettingNotExistingValue_Should_ReturnNull()
    {
        var trie = GetTrie();
        const string key = "abc";
        const string value = "a";
        trie.Add(key, value);

        var result = trie.Get("not-existing-key");
        Assert.Null(result);
    }

    [Fact]
    public void When_GettingIntermediateNodeValue_Should_ReturnNull()
    {
        var trie = GetTrie();
        const string key = "abc";
        const string value = "a";
        trie.Add(key, value);

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
        trie.Add(key, value1);
        trie.Add(key, value2);
        trie.Add(key, value3);

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
        trie.Add(key1, value1);
        trie.Add(key2, value2);
        trie.Add(key1, value3);

        var result = trie.Get(key1);
        Assert.Equal("a,c", result);
        result = trie.Get(key2);
        Assert.Equal("b", result);
    }

    [Fact]
    public void When_DefaultColisionResolver_Should_ResolveByUsingLastInsertedValue()
    {
        var trie = GetTrieDefaultResolver();
        const string key = "abc";
        const string value1 = "a";
        const string value2 = "b";
        const string value3 = "c";
        trie.Add(key, value1);
        trie.Add(key, value2);
        trie.Add(key, value3);

        var result = trie.Get(key);
        Assert.Equal("c", result);
    }

    [Fact]
    public void When_AddingValueInsideAlreadyExistingPath_Should_InsertAndRetrieveCorrectly()
    {
        var trie = GetTrie();
        const string fullKey = "abcde";
        const string newKey = "abc";
        const string value1 = "a";
        const string value2 = "b";
        trie.Add(fullKey, value1);
        trie.Add(newKey, value2);

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
        trie.Add(oldSmallKey, value2);
        trie.Add(newKey, value1);

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
        trie.Add(key, value);

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
        trie.Add(key, value);
        
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
        trie.Add(key, value);
        
        trie.Add(middleKey, value);
        var middleKeyNode = trie.GetNode(middleKey);
        Assert.True(middleKeyNode.IsMatch);
        Assert.False(middleKeyNode.IsLeaf);
    }

    [Fact]
    public void When_GettingNodeFromCharacter_Should_ReturnChild()
    {
        var trie = GetTrie();
        const string key = "abcd";
        const string value = "aaa";
        trie.Add(key, value);

        var aNode = trie.GetNode('a');
        var bNode = aNode.GetNode('b');
        var cNode = bNode.GetNode('c');
        var dNode = cNode.GetNode('d');
        Assert.True(dNode.IsLeaf);
        Assert.True(dNode.IsMatch);
    }

    [Fact]
    public void When_GettingNodeFromCharacter_NotExistingKey_Should_ReturnNull()
    {
        var trie = GetTrie();
        const string key = "abcd";
        const string value = "aaa";
        trie.Add(key, value);

        var aNode = trie.GetNode('b');
        Assert.Null(aNode);
    }

    [Fact]
    public void When_GettingNodeFromCharacter_Empty_Should_ReturnNull()
    {
        var trie = GetTrie();

        var aNode = trie.GetNode('a');
        Assert.Null(aNode);
    }

    [Fact]
    public void When_Deleting_Should_RemoveFromItemFromResults()
    {
        var trie = GetTrie();
        const string key = "abcd";
        const string value = "aaa";
        trie.Add(key, value);

        var aNode = trie.Get(key);
        Assert.NotNull(aNode);

        trie.Delete(key); 
        aNode = trie.Get(key);
        Assert.Null(aNode);
    }

    [Fact]
    public void When_Deleting_Should_RemoveNodes()
    {
        var trie = GetTrie();
        const string key = "abcd";
        const string value = "aaa";
        trie.Add(key, value);

        var valueResult = trie.Get(key);
        Assert.NotNull(valueResult);

        trie.Delete(key);
        var aNode = trie.GetNode(key);
        Assert.Null(aNode);
    }

    [Fact]
    public void When_Deleting_Should_KeepOtherExistingValues()
    {
        var trie = GetTrie();
        const string key1 = "abcd";
        const string key2 = "abcde";
        const string value = "aaa";
        trie.Add(key1, value);
        trie.Add(key2, value);

        var valueResult1 = trie.Get(key1);
        var valueResult2 = trie.Get(key1);
        Assert.NotNull(valueResult1);
        Assert.NotNull(valueResult2);

        trie.Delete(key2);
        var aNode = trie.GetNode(key2);
        Assert.Null(aNode);

        aNode = trie.GetNode(key1);
        valueResult1 = trie.Get(key1);
        Assert.NotNull(aNode);
        Assert.NotNull(valueResult1);
    }

    private Trie<string> GetTrie() => new((existingValue, newValue) => $"{existingValue},{newValue}");
    private Trie<string> GetTrieDefaultResolver() => new();
}