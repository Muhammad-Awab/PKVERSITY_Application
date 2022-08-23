﻿using ClassLibraryEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
    public class DALEducationalInfo
    {
        public static List<EntEducationalInfo> GetMatricInfo(string id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetMatric", con);
            cmd.Parameters.AddWithValue("@SID", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<EntEducationalInfo> MatricList = new List<EntEducationalInfo>();
            while (sdr.Read())
            {
                EntEducationalInfo ee = new EntEducationalInfo();
                ee.PassingDSGroup = sdr["PassingDSGroup"].ToString();
                ee.Board_University = sdr["Board_University"].ToString();
                ee.ObtainedMarks = sdr["ObtainedMarks"].ToString();
                ee.TotalMarks = sdr["TotalMarks"].ToString();
                ee.Percentage = sdr["Percentage"].ToString();
                ee.PassingYear = sdr["PassingYear"].ToString();
                ee.Institute = sdr["Institute"].ToString();
                MatricList.Add(ee);
            }
            con.Close();
            return MatricList;
        }

        public static void SaveStdMatricInfo(EntEducationalInfo ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SaveStdMatric", con);
            cmd.Parameters.AddWithValue("@SID", ee.SID);
            cmd.Parameters.AddWithValue("@PassingDSGroup", ee.PassingDSGroup);
            cmd.Parameters.AddWithValue("@Board_University", ee.Board_University);
            cmd.Parameters.AddWithValue("@ObtainedMarks", ee.ObtainedMarks);
            cmd.Parameters.AddWithValue("@TotalMarks", ee.TotalMarks);
            cmd.Parameters.AddWithValue("@Percentage", ee.Percentage);
            cmd.Parameters.AddWithValue("@PassingYear", ee.PassingYear);
            cmd.Parameters.AddWithValue("@Institute", ee.Institute);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public static void SaveStdFscInfo(EntEducationalInfo ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SaveStdFsc", con);
            cmd.Parameters.AddWithValue("@SID", ee.SID);
            cmd.Parameters.AddWithValue("@PassingDSGroup", ee.PassingDSGroup);
            cmd.Parameters.AddWithValue("@Board_University", ee.Board_University);
            cmd.Parameters.AddWithValue("@ObtainedMarks", ee.ObtainedMarks);
            cmd.Parameters.AddWithValue("@TotalMarks", ee.TotalMarks);
            cmd.Parameters.AddWithValue("@Percentage", ee.Percentage);
            cmd.Parameters.AddWithValue("@PassingYear", ee.PassingYear);
            cmd.Parameters.AddWithValue("@Institute", ee.Institute);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}