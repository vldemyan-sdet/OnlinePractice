using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace LambdatestEcom.Hooks
{
    [Binding]
    public sealed class SpecFlowHooks
    {
        private readonly ScenarioContext _scenarioContext;
        public IPage Page { get; private set; }
        private IBrowser browser;
        public IBrowserContext context;
        private bool _useState = true;
        private string stateDir = "../../../playwright/.auth";
        public string stateFile = "../../../playwright/.auth/state.json";

        public SpecFlowHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _useState = _scenarioContext.ScenarioInfo.Tags.Contains("login");
        }

        [BeforeScenario("@login")]
        public async Task BeforeScenarioWithTag()
        {
            var page = _scenarioContext.Get<IPage>("page");
            var context = _scenarioContext.Get<IBrowserContext>("context");
            await page.GotoAsync("https://ecommerce-playground.lambdatest.io/index.php?route=account/account");

            if (page.Url.EndsWith("?route=account/login"))
            {
                await page.GetByPlaceholder("E-Mail Address").FillAsync("alex.conner20241021231030@jmail.com");
                await page.GetByPlaceholder("Password").FillAsync("qweasd");
                await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

                await context.StorageStateAsync(new()
                {
                    Path = stateFile
                });
            }
        }

        [BeforeScenario(Order = 1)]
        public async Task Setup()
        {
            var ciEnv = Environment.GetEnvironmentVariable("CI");

            var playwrightDriver = await Playwright.CreateAsync();
            browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = ciEnv == "true"
            });

            if (_useState)
            {
                if (!Directory.Exists(stateDir))
                    Directory.CreateDirectory(stateDir);

                if (!File.Exists(stateFile))
                    File.WriteAllText(stateFile, "{}");
            }

            context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1920,
                    Height = 1080
                },
                StorageStatePath = _useState ? "../../../playwright/.auth/state.json" : null,
            });

            await context.Tracing.StartAsync(new()
            {
                Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            Page = await context.NewPageAsync();
            _scenarioContext["page"] = Page;
            _scenarioContext["context"] = context;


            //page.SetDefaultTimeout(5000);
        }

        [AfterScenario]
        public async Task Teardown()
        {
            await context.Tracing.StopAsync(new()
            {
                Path = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "playwright-traces",
                $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
            )
            });

            await Page.CloseAsync();
            await browser.CloseAsync();
        }
    }
}