# 🎨 Stable Diffusion Auto Image Generator

A fully automated image-generation pipeline powered by **Stable Diffusion WebUI (AUTOMATIC1111)**.

This project demonstrates how to orchestrate fully automatic prompt-based art generation using:

- C# (.NET 6+)
- Local GPU hardware
- Stable Diffusion API

> ⚡ Built for experimentation, automation, and dataset generation.

---

## 🔥 Highlights

✔️ Fully automated `txt2img` pipeline (no user interaction required)  
✔️ Large curated cinematic prompt list  
✔️ Automatic Base64 → PNG conversion  
✔️ Infinite generation loop  
✔️ Error-resilient (timeouts, empty outputs, API failures)  
✔️ Configurable steps, sampler, resolution, CFG scale  
✔️ Mid-range GPU friendly  

---

## 💻 Test Environment

This project was developed and benchmarked on:

- **CPU:** Intel Core i5 (12th Gen)  
- **GPU:** NVIDIA RTX 3050 Ti (Laptop)  
- **RAM:** 16 GB  
- **Stable Diffusion WebUI:** AUTOMATIC1111  
- **.NET Version:** .NET 6+  

### ⏱️ Typical Generation Speed

- **512x512:** ~5–7 seconds  
- **1080x700 (default):** ~10–15 seconds  

---

## 🖼️ Sample Outputs

Below are example images generated using this exact script and hardware:

```
samples/sample1.png
samples/sample2.png
samples/sample3.png
samples/sample4.png
samples/sample5.png
```

(Upload your images into the `samples/` folder to display them in GitHub.)

---

## 📦 Requirements

To run this project you need:

- .NET 6 or newer
- Stable Diffusion WebUI (AUTOMATIC1111)
- API enabled in WebUI:
  
  `Settings → API → Enable API`

Stable Diffusion must be running at:

```
http://127.0.0.1:7860
```

---

## 🚀 Installation

### 1️⃣ Start Stable Diffusion WebUI

```
webui-user.bat
```

---

### 2️⃣ Clone This Repository

```
git clone https://github.com/username/stable-diffusion-auto-generator.git
cd stable-diffusion-auto-generator
```

---

### 3️⃣ Run the Program

```
dotnet run
```

---

## 🧠 How It Works

The script performs the following loop:

1. Selects a prompt from the predefined `positivePrompts` list  
2. Sends a POST request to `/sdapi/v1/txt2img`  
3. Receives a Base64-encoded PNG  
4. Converts and saves it as:

```
output_YYYYMMDD_HHMMSS.png
```

5. Waits for a configured delay  
6. Moves to the next prompt  

The cycle repeats indefinitely.

Perfect for:

- Automated art generation
- Dataset creation
- Prompt experimentation
- Stress testing hardware

---

## 🔧 Code Structure Overview

**Program.cs**
- Main infinite loop
- HTTP API calls
- Image conversion & saving

**positivePrompts**
- Large curated prompt list
- Cinematic / creative presets

**Error Handling**
- Empty image responses
- API failures
- Connection timeouts
- Invalid responses

---

## 🛠️ Customization

You can easily modify:

```
steps
cfg_scale
width / height
sampler_index
generation delay
prompt list & order
inference seed
```

> Fine-tuning these parameters significantly impacts output quality and speed.

---

## ⚠️ Troubleshooting

### ❌ Empty Images / "images missing"

Possible causes:

- GPU overload  
- Model loading error  
- Sampler too heavy  
- VRAM overflow  

---

### ❌ Connection Refused

- WebUI not running  
- Incorrect port  
- API not enabled  

---

### 🐢 Slow Generation

Try:

- Lower resolution  
- Reduce `steps`  
- Use lighter sampler  
- Enable VRAM optimization in WebUI  

---

## 📄 License

Distributed under the MIT License.

---

> This project was created for experimentation and fun — but it scales surprisingly well for automated dataset generation.
