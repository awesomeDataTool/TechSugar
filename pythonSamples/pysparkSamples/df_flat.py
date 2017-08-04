import numpy as np

import findspark
findspark.init()

from pyspark.ml.regression import LinearRegression, LinearRegressionModel
from pyspark.ml.linalg import Vectors, VectorUDT
from pyspark.sql import SparkSession
from pyspark.sql.types import *
from pyspark.sql import SQLContext, Row
from pyspark.sql.types import FloatType
# from pyspark.sql import 
from pyspark.sql.functions import first, col
from pyspark.ml.feature import VectorAssembler


def convert_to_flat_by_pandas(df):
    pandas_data_frame = df.toPandas()
    all_keys = pandas_data_frame['key'].unique()

    flat_values = []
    for key in all_keys:
        key_rows = pandas_data_frame.loc[pandas_data_frame['key'] == key]
        key_rows = key_rows.sort_values(by=['subkey'])
        
        parameter_values = key_rows['parameter']
        parameter_value = parameter_values.real[0]        

        key_reference_value = [reference_values for reference_values in key_rows['reference']]

        flat_values.append((parameter_value, key_reference_value))

    loaded_data = [(np.asscalar(label), Vectors.dense(features)) for (label, features) in flat_values]
    spark_df = spark.createDataFrame(loaded_data, ["label", "features"])
    return spark_df

def convert_to_flat_by_sparkpy(df):
    # subkeys = df.select("subkey").dropDuplicates().rdd.map(lambda r: r[0]).collect()
    subkeys = df.select("subkey").dropDuplicates().collect()
    subkeys = [s[0] for s in subkeys]
    print('subkeys: ', subkeys)
    assembler = VectorAssembler().setInputCols(subkeys).setOutputCol("features")
    spark_df = assembler.transform(df.groupBy("key", "parameter").pivot("subkey").agg(first(col("reference"))))    
    spark_df = spark_df.withColumnRenamed("parameter", "label")
    spark_df = spark_df.select("label", "features")
    # spark_df = spark_df.select(spark_df.label, Vectors.dense(spark_df.features))
    return spark_df

if __name__ == "__main__":
    print("main started")

    spark = SparkSession\
        .builder\
        .appName("df-flat-pyspark")\
        .getOrCreate()
    print("spark version:", spark.version)

    data = [
        {'key': 'key1', 'subkey': 'subkey1', 'parameter': 45.0, 'reference': 10.0},
        {'key': 'key1', 'subkey': 'subkey3', 'parameter': 45.0, 'reference': 20.0},
        {'key': 'key1', 'subkey': 'subkey2', 'parameter': 45.0, 'reference': 15.0},
        {'key': 'key2', 'subkey': 'subkey2', 'parameter': 70.0, 'reference': 40.0},
        {'key': 'key2', 'subkey': 'subkey3', 'parameter': 70.0, 'reference': 50.0},
        {'key': 'key2', 'subkey': 'subkey1', 'parameter': 70.0, 'reference': 30.0}
    ]
    
    original_df = spark.createDataFrame(data)
    print('original data:')
    original_df.show()

    flat_df = convert_to_flat_by_pandas(original_df)
    print("schema of result's data frame:")
    flat_df.printSchema()
    print('result data (by pandas):')
    flat_df.show()    

    flat_df = convert_to_flat_by_sparkpy(original_df)
    print("schema of result's data frame:")
    flat_df.printSchema()
    print('result data (by sparkby):')
    flat_df.show()    

    print("main completed")