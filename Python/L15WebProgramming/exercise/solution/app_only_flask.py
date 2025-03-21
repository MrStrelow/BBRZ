from flask import Flask, render_template, request, jsonify
from flask_cors import CORS  # Correct import for flask-cors

# Initialize Flask app
app = Flask(__name__)

# Enable CORS for your frontend (allow requests from specific origins)
CORS(app, origins=["http://127.0.0.1:5000"], methods=["GET", "POST"])

# A simple route to be handled by Flask (the frontend)
@app.route("/")
def index():
    return render_template("index_only_flask.html")  # Renders a simple HTML page

# Flask route for GET request (API)
@app.route("/api/data", methods=["GET"])
def get_data():
    return jsonify({"message": "This is a GET request response from Flask"})

# Flask route for POST request (API)
@app.route("/api/data", methods=["POST"])
def post_data():
    data = request.get_json()  # Retrieve JSON data sent in the POST request
    return jsonify({"message": "This is a POST request response from Flask", "received_data": data})

# Run the Flask app
if __name__ == "__main__":
    app.run(port=5000)
