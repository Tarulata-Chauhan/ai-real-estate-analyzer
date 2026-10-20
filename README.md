# AI-Powered Real Estate Market Analyzer

A .NET 8 Worker Service designed to ingest unstructured property listings, parse the raw text using AI, and output structured investment scoring data.

## Business Problem
Real estate listings contain valuable hidden data (e.g., roof age, renovation status) buried within unstructured paragraph descriptions. This background service acts as a consumer in a distributed architecture, polling a message queue for new listings and using LLM techniques to normalize that data into actionable SQL models.

## Architecture
* **Framework:** .NET 8 Worker Service
* **Pattern:** Message Queue Consumer / Background Processor
* **Domain:** Frederick, MD Real Estate (Targeting 3-4 Bedroom Homes)

## Features
* **Unstructured Data Parsing:** Extracts specific features (basements, roofs, renovations) from raw text descriptions.
* **Investment Scoring Algorithm:** Automatically scores properties based on extracted custom lifestyle criteria.
* **Continuous Processing:** Designed to run continuously, polling message queues like AWS SQS or Azure Service Bus.

## How to Run Locally
1. Ensure the .NET 8 SDK is installed.
2. Clone this repository.
3. Open a terminal in the root directory.
4. Run `dotnet restore` to install dependencies.
5. Run `dotnet run` to start the worker. 
6. The service will output the simulated property processing directly to the console.
