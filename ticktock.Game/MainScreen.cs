using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK.Graphics;

namespace ticktock.Game
{
    public class MainScreen : Screen
    {
        private SpriteText currentTime, currentDate, warning;
        private float bouncingOpacity = 0.4f;
        private float deltaOpacity = 0.0005f;

        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new Box
                {
                    Colour = Color4.Black,
                    RelativeSizeAxes = Axes.Both,
                },
                new SpriteText
                {
                    Y = 20,
                    Text = "Tick Tock",
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                    Font = FontUsage.Default.With(size: 40)
                },
                // new SpinningBox
                // {
                //     Anchor = Anchor.Centre,
                // },
                currentDate = new SpriteText
                {
                    Y = -120,
                    Text = "loading...",
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Font = FontUsage.Default.With(size: 60),
                    Colour = Color4.White.Opacity(0.6f)
                },
                currentTime = new SpriteText
                {
                    Y = 0,
                    Text = "loading...",
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Font = FontUsage.Default.With(size: 140)
                },
                warning = new SpriteText
                {
                    Y = -40,
                    Text = "Press F11 to exit fullscreen mode and return to Windows",
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.Centre,
                    Font = FontUsage.Default.With(size: 30),
                    Colour = Color4.White.Opacity(0.4f)
                }
            };
        }

        protected override void Update() {
            base.Update();

            if (bouncingOpacity >= 0.4f || bouncingOpacity <= 0.0f) {
                deltaOpacity = -deltaOpacity;
            }
            bouncingOpacity += deltaOpacity;

            currentDate.Text = System.DateTime.Now.ToString("D");
            currentTime.Text = System.DateTime.Now.ToString("T");
            warning.Colour = Color4.White.Opacity(bouncingOpacity);
        }
    }
}
