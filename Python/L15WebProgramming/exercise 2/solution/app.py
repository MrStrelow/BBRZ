import os
from fastapi import FastAPI, File, UploadFile
from fastapi.responses import JSONResponse, HTMLResponse
from fastapi.staticfiles import StaticFiles
from fastapi.middleware.cors import CORSMiddleware
from fastapi.templating import Jinja2Templates
from starlette.requests import Request

# Initialize FastAPI app
app = FastAPI()

# Enable CORS for the frontend
app.add_middleware(
    CORSMiddleware,
    allow_origins=["http://127.0.0.1:5000"],  # Allow requests from Flask frontend (or any other frontend)
    allow_credentials=True,
    allow_methods=["GET", "POST"],  # Allow specific methods
    allow_headers=["*"],  # Allow all headers
)

# Folder to store uploaded images
UPLOAD_FOLDER = 'uploads'
if not os.path.exists(UPLOAD_FOLDER):
    os.makedirs(UPLOAD_FOLDER)

# Serve uploaded files (so they can be accessed via the browser)
app.mount("/uploads", StaticFiles(directory=UPLOAD_FOLDER), name="uploads")

# Setup template directory
templates = Jinja2Templates(directory="html")

# FastAPI route for uploading image
@app.post("/upload")
async def upload_image(file: UploadFile = File(...)):
    try:
        # Save the uploaded image file
        file_location = os.path.join(UPLOAD_FOLDER, file.filename)
        with open(file_location, "wb") as f:
            f.write(await file.read())
        return {"message": "File uploaded successfully", "filename": file.filename}
    except Exception as e:
        return JSONResponse(content={"error": str(e)}, status_code=400)

# FastAPI route for handling GET requests (simple response)
@app.get("/api/data")
async def get_data():
    return {"message": "This is a GET request response from FastAPI"}

# FastAPI route to list uploaded images
@app.get("/uploaded_images")
async def get_uploaded_images():
    # List all files in the uploads folder
    uploaded_files = os.listdir(UPLOAD_FOLDER)
    image_files = [file for file in uploaded_files if file.lower().endswith(('.png', '.jpg', '.jpeg', '.gif', '.bmp'))]
    return {"images": image_files}

# Frontend route (serving HTML for file upload and display)
@app.get("/")
async def get_html(request: Request):
    images = os.listdir(UPLOAD_FOLDER)  # Get list of uploaded files
    images = [img for img in images if img.lower().endswith(('.png', '.jpg', '.jpeg', '.gif', '.bmp'))]  # Filter image files
    return templates.TemplateResponse("index_simpel.html", {"request": request, "images": images})
    # return templates.TemplateResponse("index.html", {"request": request, "images": images})
