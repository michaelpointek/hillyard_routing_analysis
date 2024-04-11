# Hillyard Routing Analysis

**Overview**

This repository contains the code and data for analyzing routing patterns for Hillyard, including clustering analysis based on various features.

**Contents**

Notebooks/: Jupyter Notebooks containing code for data analysis and visualization.

Resources/: Data files used in the analysis.

1###_cluster_centroids_##.csv: CSV file containing the centroids of the clusters obtained from k-means clustering, with the first number corresponding to the facility location and the last number corresponding to the number of clusters produced. 

1###_clustered_stops_##.csv: CSV file containing every stop with its corresponding cluster label, with the first number corresponding to the facility location and the last number corresponding to the number of clusters produced. 

README.md: This file, providing an overview of the repository.


**Setup**

Clone the repository to your local machine:

`git clone https://github.com/michaelpointek/hillyard_routing_analysis.git`

Ensure you have Python and Jupyter Notebook installed.


Install the required Python libraries:

`pip install pandas numpy scikit-learn matplotlib`


**Usage**

Open Jupyter Notebook:

`jupyter notebook`

Navigate to the notebooks/ directory and open the desired notebook to explore the analysis. Additional reference files can be added to the Resources folder to analyze 
additional locations

**Data**

routing_analysis.csv: The original dataset containing routing information for Hillyard location 1430 Delaware Valley.

**Contributors**

Michael Pointek

**License**

Apache 2.0
