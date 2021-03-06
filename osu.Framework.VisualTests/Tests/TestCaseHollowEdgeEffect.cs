﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Testing;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Framework.VisualTests.Tests
{
    public class TestCaseHollowEdgeEffect : GridTestCase
    {
        public TestCaseHollowEdgeEffect() : base(2, 2)
        {
        }

        public override string Description => @"Hollow Container with EdgeEffect";

        public override void Reset()
        {
            base.Reset();

            const float size = 60;

            float[] cornerRadii = { 0, 0.5f, 0, 0.5f };
            float[] alphas = { 0.5f, 0.5f, 0, 0 };
            EdgeEffectParameters[] edgeEffects =
            {
                new EdgeEffectParameters
                {
                    Type = EdgeEffectType.Glow,
                    Colour = Color4.Khaki,
                    Radius = size,
                    Hollow = true,
                },
                new EdgeEffectParameters
                {
                    Type = EdgeEffectType.Glow,
                    Colour = Color4.Khaki,
                    Radius = size,
                    Hollow = true,
                },
                new EdgeEffectParameters
                {
                    Type = EdgeEffectType.Glow,
                    Colour = Color4.Khaki,
                    Radius = size,
                    Hollow = true,
                },
                new EdgeEffectParameters
                {
                    Type = EdgeEffectType.Glow,
                    Colour = Color4.Khaki,
                    Radius = size,
                    Hollow = true,
                },
            };

            for (int i = 0; i < Rows * Cols; ++i)
            {
                Cell(i).Add(new Drawable[]
                {
                    new SpriteText
                    {
                        Text = $"{nameof(CornerRadius)}={cornerRadii[i]} {nameof(Alpha)}={alphas[i]}",
                        TextSize = 20,
                    },
                    new Container()
                    {
                        Size = new Vector2(size),
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,

                        Masking = true,
                        EdgeEffect = edgeEffects[i],
                        CornerRadius = cornerRadii[i] * size,

                        Children = new Drawable[]
                        {
                            new Box()
                            {
                                RelativeSizeAxes = Axes.Both,
                                Colour = Color4.Aqua,
                                Alpha = alphas[i],
                            },
                        },
                    },
                });
            }
        }
    }
}
