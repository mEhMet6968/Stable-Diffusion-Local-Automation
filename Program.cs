using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

class Program
{
	static int deneme = 0;
	static readonly HttpClient client = new HttpClient();

	static readonly List<string> positivePrompts = new List<string>
	{
		"a majestic lion resting under a tree in golden hour lighting",
	"a futuristic city skyline with flying vehicles at night",
	"a close-up of a snowflake captured with a macro lens",
	"a photorealistic steam train crossing a snowy bridge",
	"a wizard casting a glowing spell in a dark forest",
	"a realistic portrait of a pirate captain with scars",
	"a colorful coral reef with tropical fish and sunbeams",
	"a surreal floating castle above the clouds at sunset",
	"a deserted post-apocalyptic city overgrown with plants",
	"a cinematic scene of a samurai in cherry blossom rain",
	"a medieval banquet hall filled with knights and candles",
	"an old bookstore with dusty books and warm lighting",
	"a snowy village under the northern lights in winter",
	"a giant dragon flying over a medieval city at dusk",
	"a vibrant Indian street market during Holi festival",
	"a close-up of a falcon mid-flight with sharp details",
	"a peaceful lakeside cabin surrounded by autumn trees",
	"a fantasy queen on her throne with glowing jewelry",
	"a crashed spaceship in a jungle with overgrown vines",
	"a cozy coffee shop on a rainy day with blurred windows",
	"a modern skyscraper reflecting the sky in sunset",
	"a Viking longship sailing through rough northern seas",
	"a polar bear crossing melting ice in twilight",
	"a starry desert night with camels and campfire glow",
	"an abandoned cathedral overrun by vegetation",
	"a realistic portrait of an astronaut removing helmet",
	"a haunted Victorian house on a foggy hill",
	"a realistic painting of a jazz band in a smoky club",
	"a helicopter flying over a volcano eruption",
	"a Roman gladiator preparing for battle in the arena",
	"a peaceful Zen temple in misty mountains at dawn",
	"a macro shot of a bee on a sunflower with fine details",
	"a futuristic robot helping an elderly person cross street",
	"a royal carriage in a snowy fairytale forest",
	"a forest nymph surrounded by glowing fireflies",
	"a hot air balloon festival at sunrise",
	"a realistic underwater city inhabited by mermaids",
	"a sci-fi desert outpost under twin suns",
	"a cowboy riding through a stormy canyon",
	"a highly detailed violin being played by a blind man",
	"a knight rescuing a princess from a dragon's cave",
	"a refugee camp in a war-torn futuristic city",
	"a female warrior on a futuristic motorbike",
	"a magical potion room full of glowing vials",
	"a hummingbird feeding on bright red flowers",
	"a surreal melting clock landscape (Dali-inspired)",
	"a carnival at night with vibrant lights and fireworks",
	"a photorealistic plate of sushi with elegant plating",
	"a horse galloping through shallow ocean waves",
	"a lighthouse during a violent thunderstorm",
	"a scientist examining alien life in a space lab",
	"a peaceful rice terrace landscape at golden hour",
	"a dragon curled around an ancient tower",
	"a firefighter rescuing a kitten from a burning building",
	"a musical conductor in action with dramatic lighting",
	"a World War II soldier in a trench with realism",
	"a realistic snow leopard in a rocky mountain pass",
	"a misty bamboo forest with a lone traveler",
	"a magical school classroom with floating objects",
	"a photorealistic forest elf with intricate tattoos",
	"a market street in Morocco at sunset",
	"a jazz pianist playing on a floating stage over water",
	"a refugee mother carrying child in dystopian ruins",
	"a biomechanical heart pumping inside a glass chest",
	"a chessboard mid-game between two grandmasters",
	"a sailboat in stormy seas with dramatic sky",
	"a high-speed bullet train in a neon-lit city",
	"a massive waterfall cascading into a glowing cave",
	"a dragon egg hatching with intense lighting",
	"a royal feast scene in a medieval castle",
	"a steampunk airship flying over snowy mountains",
	"a ballerina dancing on a rooftop at sunset",
	"a lone astronaut walking on a frozen exoplanet",
	"a realistic underwater scuba diver exploring ruins",
	"a roaring fire in a stone fireplace with cozy vibes",
	"a ninja leaping between rooftops at midnight",
	"a glowing phoenix reborn from ashes in darkness",
	"a close-up of a wolf’s eye reflecting a forest",
	"a military drone flying over desert terrain",
	"a realistic chocolate cake with drizzled syrup",
	"a glacial cave with shimmering ice walls",
	"a soldier comforting a wounded ally in battle",
	"a whale breaching under the northern lights",
	"a realistic submarine underwater above ocean trench",
	"a detective in 1940s noir city street at night",
	"a grandmother baking cookies in a rustic kitchen",
	"a spaceship traveling through a wormhole",
	"a post-apocalyptic survivor scavenging supplies",
	"a violin soloist on a grand concert stage",
	"a flock of birds flying through pink sunset clouds",
	"a photo-real antique pocket watch ticking close-up",
	"a wolf howling on a cliff under full moon",
	"a monk meditating under a waterfall",
	"a snowy forest clearing with animal tracks",
	"a child discovering a glowing cave",
	"a warrior walking through battlefield smoke",
	"a photo of galaxy from mountaintop observatory",
	"a time traveler stepping out of a portal",
	"a submarine exploring Titanic wreck",
	"a realistic phoenix feather burning midair",
	"a chessboard floating in space with stars",
	"a lonesome cowboy looking at stars on desert",
	"a dancer mid-spin in a spotlight on wooden floor",
	"a realistic gold coin pile reflecting light",
	"a statue being uncovered by archaeologists",
	"a dense jungle with ruins and monkeys",
	"a peaceful tea ceremony with fine porcelain",
	"a magical key floating above an ancient stone",
	"a science experiment going wrong in lab explosion",
	"a female AI android in a glass chamber",
	"a night fishing boat glowing with lanterns",
	"a mountaineer on summit holding flag",
	"a magical tree growing in the center of a city",
	"a firefly-filled cave with glowing crystals",
	"a warrior monk in a burning monastery",
	"a child flying a kite on grassy hill",
	"a massive floating whale above a desert",
	"a cyberpunk alley cat with neon eyes",
	"a snowy owl in flight with sharp feathers",
	"a blacksmith forging a sword in molten heat",
	"a violin breaking apart into butterflies",
	"a candle burning upside-down in zero gravity",
	"a honeybee hive in extreme close-up detail",
	"a glass of water with visible microscopic life",
	"a gladiator entering a colosseum at sunset",
	"a bioluminescent frog in a rainforest puddle",
	"a toddler playing with a robotic dog",
	"a man standing in rain with umbrella and neon lights",
	"a realistic portrait of an elderly traveler",
	"a martial artist mid-kick with dynamic lighting",
	"a surreal hand reaching out of a mirror",
	"a couple watching a meteor shower in silence",
	"a hummingbird frozen mid-flap with water droplets",
	"a glowing crystal heart inside an ancient statue",
	"a windmill in a tulip field under clear skies",
	"a dramatic cloudscape over still ocean water",
	"a close-up of violin strings vibrating",
	"a rocket launching with dust and fire",
	"a medieval king in golden armor",
	"a realistic steam rising from a hot bowl of soup",
	"a quiet village street at dawn with fog",
	"a polar bear and cub walking across cracked ice",
	"a black panther hiding in shadows with glowing eyes",
	"a subway musician playing violin with emotion",
	"a young boy reaching toward a shooting star",
	"a frozen lake with a single leaf trapped inside",
	"a violin carved from transparent glass",
	"a roaring lion with water splashing off mane",
	"a ghost ship glowing under moonlight",
	"a dancer surrounded by floating petals in slow motion"

	};


	static async Task Main()
	{
	

		while (true)
		{
			// Mevcut promptları çek
			string positive = positivePrompts[deneme];

			var payload = new
			{
				prompt = positive,
				negative_prompt = "",
				steps = 76,
				cfg_scale = 7,
				width = 1080,
				height = 700,
				sampler_index = "Euler",
				seed = -1,
				batch_size = 1,
				n_iter = 1,
				restore_faces = false,
				tiling = false,
				send_images = true
			};

			var json = JsonSerializer.Serialize(payload);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			try
			{
				using var response = await client.PostAsync("http://127.0.0.1:7860/sdapi/v1/txt2img", content);

				if (!response.IsSuccessStatusCode)
				{
					var err = await response.Content.ReadAsStringAsync();
					Console.WriteLine($"❌ Error {(int)response.StatusCode}: {response.StatusCode}");
					Console.WriteLine(err);
				}
				else
				{
					var result = await response.Content.ReadAsStringAsync();
					using var doc = JsonDocument.Parse(result);
					var root = doc.RootElement;

					if (root.TryGetProperty("images", out var images) && images.GetArrayLength() > 0)
					{
						var b64 = images[0].GetString();
						if (!string.IsNullOrEmpty(b64))
						{
							var bytes = Convert.FromBase64String(b64);
							var file = Path.Combine(Directory.GetCurrentDirectory(),
													  $"output_{DateTime.Now:yyyyMMdd_HHmmss}.png");
							await File.WriteAllBytesAsync(file, bytes);
							Console.WriteLine($"✅ Saved: {file}");
						}
						else
						{
							Console.WriteLine("⚠️ Boş base64 geldi.");
						}
					}
					else
					{
						Console.WriteLine("⚠️ 'images' eksik veya boş.");
						Console.WriteLine("Raw JSON: " + result);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("🚫 Exception: " + ex.Message);
			}

			// 60 saniye bekle
			Console.WriteLine($"⏳ 60s waiting (deneme={deneme})...");
			await Task.Delay(TimeSpan.FromSeconds(150));

			// sayacı artır, 150’e gelince sıfırla
			deneme = (deneme + 1) % positivePrompts.Count;
		}
	}
}
