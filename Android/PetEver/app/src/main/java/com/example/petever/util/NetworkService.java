package com.example.petever.util;

import okhttp3.MultipartBody;
import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.http.Multipart;
import retrofit2.http.POST;
import retrofit2.http.Part;

public interface NetworkService {
    @Multipart
    @POST("/image")
    Call<ResponseBody> uploadImage(@Part MultipartBody.Part image);
}