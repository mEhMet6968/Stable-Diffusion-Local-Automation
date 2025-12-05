Stable Diffusion Auto Image Generator

This codes can be upgrade for example add negative prompt or taller prompts should be better outputs. This project was just  for fun.

A fully automated image-generation pipeline powered by Stable Diffusion WebUI (AUTOMATIC1111). This tool cycles through an extensive list of high‑quality prompts, generates images on your local Stable Diffusion instance, saves them in PNG format, and repeats the process indefinitely.
This repository demonstrates how to orchestrate fully automatic prompt-based art generation using simple C# code, local GPU hardware, and the SD API.

🔥 Highlights

✔️ Automated txt2img pipeline (no user interaction required)

✔️ Large curated prompt list

✔️ Saves Base64 → PNG automatically

✔️ Error‑resilient loop (timeouts, empty outputs, API failures)

✔️ Configurable generation steps, sampler, resolution, CFG scale

✔️ Hardware-friendly — designed for mid‑range GPUs

💻 Test Environment

This project was developed and benchmarked on the following hardware:

CPU: Intel Core i5 12th Gen

GPU: NVIDIA RTX 3050 Ti (Laptop Edition)

RAM: 16 GB

Stable Diffusion WebUI: AUTOMATIC1111

.NET Version: .NET 6+

Typical generation speed on this system:

512x512: ~5–7 seconds

1080×700 (project default): ~10–15 seconds

🖼️ Sample Outputs

Below are 5 sample images generated using this exact script and hardware:

(You can drag & drop your images here after uploading them to the repo:)

samples/sample1.png

samples/sample2.png

samples/sample3.png

samples/sample4.png

samples/sample5.png

📦 Requirements

To run this project, you need:

.NET 6 or newer

Stable Diffusion WebUI (AUTOMATIC1111)

API enabled in WebUI:

Settings → API → Enable API

Stable Diffusion must be running at:

http://127.0.0.1:7860

🚀 Installation

1) Start Stable Diffusion WebUI

webui-user.bat

2) Clone this repository

git clone https://github.com/username/stable-diffusion-auto-generator.git
cd stable-diffusion-auto-generator

3) Run the program

dotnet run

🧠 How It Works

The script:

Selects a prompt from the predefined positivePrompts list

Sends a POST request to /sdapi/v1/txt2img

Receives a Base64-encoded PNG

Converts and saves it as:

output_YYYYMMDD_HHMMSS.png

Waits a configured duration

Moves to the next prompt

It repeats forever—perfect for generating large image datasets.

🔧 Code Structure Overview

Program.cs: Main loop, HTTP calls, saving images

positivePrompts: Huge list of cinematic / creative prompts

Error handling: Missing images, API errors, failed connections

🛠️ Customization
//this details makes perfect 👌
You can change:

steps

cfg_scale

width / height

sampler_index

Delay between generations

Prompt list & order

Inference seed

⚠️ Troubleshooting

Empty images / "images missing"

GPU overloaded

Model error

Sampler too heavy

Connection refused

WebUI not running

Using a different port

Slow generation

Increase VRAM efficiency by lowering resolution or steps

📄 License

Distributed under the MIT License.
