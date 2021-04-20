using MedicalExamination.Domain.Models.MedicalRecord.ExaminationRooms;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalExamination.Domain.Models.MedicalRecord
{
    public class MedicalRecordDetails
    {
        public AbdominalUltrasound AbdominalUltrasound { get; set; }
        public BloodTests BloodTests { get; set; }
        public BreastUltrasound BreastUltrasound { get; set; }
        public CardiacUltrasoundProbes CardiacUltrasoundProbes { get; set; }
        public ChestXray ChestXray { get; set; }
        public ClinicalUrineTests ClinicalUrineTests { get; set; }
        public DermatologyExamination DermatologyExamination { get; set; }
        public InternalMedicineExamination InternalMedicineExamination { get; set; }
        public MedicalImagingDiagnostics MedicalImagingDiagnostics { get; set; }
        public NeurologyExamination NeurologyExamination { get; set; }
        public ObstetricsAndGynecologyExamination ObstetricsAndGynecologyExamination { get; set; }
        public OphthalmologyExamination OphthalmologyExamination { get; set; }
        public OralAndMaxillofacialExamination OralAndMaxillofacialExamination { get; set; }
        public OtorhinolaryngologyExamination OtorhinolaryngologyExamination { get; set; }
        public PhysicalExamination PhysicalExamination { get; set; }
        public SurgeryExamination SurgeryExamination { get; set; }
        public ThyroidUltrasound ThyroidUltrasound { get; set; }
    }
}
