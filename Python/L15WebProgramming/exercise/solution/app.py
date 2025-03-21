from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware
from fastapi.responses import HTMLResponse
from fastapi import Request
import uvicorn
from flask import Flask, render_template
from threading import Thread

# Initialize Flask app
flask_app = Flask(__name__)

# Initialize FastAPI app
fastapi_app = FastAPI()

# Add CORS middleware to FastAPI
fastapi_app.add_middleware(
    CORSMiddleware,
    allow_origins=["http://127.0.0.1:5000"],  # Allow your Flask frontend's origin
    allow_credentials=True,
    allow_methods=["GET", "POST"],  # Allow specific methods (GET, POST, etc.)
    allow_headers=["*"],  # Allow all headers
)

# A simple route to be handled by Flask (the frontend)
@flask_app.route("/")
def index():
    return render_template("index.html")  # Renders a simple HTML page

# FastAPI route for GET request
@fastapi_app.get("/api/data")
async def get_data():
    return {"message": "This is a GET request response from FastAPI"}

# FastAPI route for POST request
@fastapi_app.post("/api/data")
async def post_data(request: Request):
    data = await request.json()
    return {"message": "This is a POST request response from FastAPI", "received_data": data}

# Running both Flask and FastAPI apps
def run_flask():
    flask_app.run(port=5000)

def run_fastapi():
    uvicorn.run(fastapi_app, host="0.0.0.0", port=8000)

if __name__ == "__main__":
    # Start Flask server in a separate thread
    flask_thread = Thread(target=run_flask)
    flask_thread.start()

    # Start FastAPI server
    run_fastapi()
