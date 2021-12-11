cmake_minimum_required(VERSION 3.21)
project(pocket_import_helper)

set(CMAKE_CXX_STANDARD 14)
set (CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -static")

add_executable(pocket_import_helper main.cpp)
