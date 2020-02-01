﻿using JollySamurai.UnrealEngine4.T3D.Parser;
using JollySamurai.UnrealEngine4.T3D.Processor;

namespace JollySamurai.UnrealEngine4.T3D.Material
{
    public class MaterialExpressionDesaturation : Node
    {
        public ParsedPropertyBag Input { get; }
        public ParsedPropertyBag Fraction { get; }

        public MaterialExpressionDesaturation(string name, ParsedPropertyBag input, ParsedPropertyBag fraction, int editorX, int editorY) : base(name, editorX, editorY)
        {
            Input = input;
            Fraction = fraction;
        }
    }

    public class MaterialExpressionDesaturationProcessor : NodeProcessor
    {
        public override string Class => "/Script/Engine.MaterialExpressionDesaturation";

        public MaterialExpressionDesaturationProcessor()
        {
            AddRequiredAttribute("Name", PropertyDataType.String);

            AddOptionalProperty("Input", PropertyDataType.AttributeList);
            AddOptionalProperty("Fraction", PropertyDataType.AttributeList);
            AddOptionalProperty("MaterialExpressionEditorX", PropertyDataType.Integer);
            AddOptionalProperty("MaterialExpressionEditorY", PropertyDataType.Integer);

            AddIgnoredProperty("Material");
            AddIgnoredProperty("MaterialExpressionGuid");
        }

        public override Node Convert(ParsedNode node, Node[] children)
        {
            return new MaterialExpressionDesaturation(node.FindAttributeValue("Name"), ValueUtil.ParseAttributeList(node.FindPropertyValue("Input")), ValueUtil.ParseAttributeList(node.FindPropertyValue("Fraction")), ValueUtil.ParseInteger(node.FindPropertyValue("MaterialExpressionEditorX") ?? "0"), ValueUtil.ParseInteger(node.FindPropertyValue("MaterialExpressionEditorY") ?? "0"));
        }
    }
}
