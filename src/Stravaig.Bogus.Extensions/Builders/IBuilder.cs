using System.Text;

namespace Stravaig.Bogus.Extensions.Builders;

interface IBuilder
{
    /// <summary>
    /// Generates a string based on the builder's inputs.
    /// </summary>
    /// <returns>The built string.</returns>
    string Generate();

    /// <summary>
    /// Appends the generated string to the StringBuilder based on the builder's inputs.
    /// </summary>
    /// <param name="sb">The string builder that is appended to.</param>
    void Generate(StringBuilder sb);
}