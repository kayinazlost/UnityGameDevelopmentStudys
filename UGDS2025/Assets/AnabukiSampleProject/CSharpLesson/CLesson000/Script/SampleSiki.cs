using UnityEngine;

/// <summary>
/// C#�̊�{�I�Ȑ���\���iif�Aswitch�Afor�Awhile�Aforeach�j���w�ԃX�N���v�g
/// �e�\����3�Ⴘ�p�ӂ��ADebug.Log�ŕ�����₷���\��
/// </summary>
public class SampleSiki : MonoBehaviour
{
    void Start()
    {
        //if����
        ShowIfExamples();
        //Switch�`Case����
        ShowSwitchExamples();
        //for����
        ShowForExamples();
        //While����
        ShowWhileExamples();
        //Foreach����
        ShowForeachExamples();
    }

    // ========================
    // if���̗�
    // ========================
    void ShowIfExamples()
    {
        Debug.Log("==== if���̗� ====");

        int score = 80;

        ///��{�I��if����
        ///if(��r����)�ŁA��������������Ă���ꍇ����{ }���̏��������s����܂��B
        ///{ }�̏������I��������A���̂܂�if���ߏ����͏I�����A���̍s�̃v���O���������s����܂��B
        if (score >= 70)
        {
            Debug.Log("���i�ł��I");
        }

        ///if�`else
        ///if���߂Ŕ�r�����������������Ȃ��ꍇ�́Aelse{ }���̏��������s����܂��B
        ///����Ӗ��A�I�����̂悤�Ȃ��̂ƍl����΂����ł��傤
        if (score < 50)
        {
            Debug.Log("�ԓ_�ł�");
        }
        else
        {
            Debug.Log("���v���A���Ȃ��B");
        }

        ///if �` else if �` else
        ///������Ɠ���ł����A��r��������������Ȃ������ہA���̐V������r�������`�F�b�N���鎖���\
        ///���̏ꍇ�A�X�R�A���A90�ȏォ�A����ȊO��?�ŁA��������ȊO�̏ꍇ�A�V���������Ƃ���
        ///�X�R�A��70�ȏォ�A����ȊO���̕���ɂȂ�܂��B
        ///�ܘ_�A���l��else if�Ōq���鎖���ł��܂����A�������������Ȃ茩�Â炭�Ȃ�̂ł����߂��܂���B
        if (score >= 90)
        {
            Debug.Log("�D�G�I");
        }
        else if (score >= 70)
        {
            Debug.Log("�ǂ����сI");
        }
        else
        {
            Debug.Log("��Ԃ������тŗ��ށB");
        }
    }

    // ========================
    // switch���̗�
    // ========================
    void ShowSwitchExamples()
    {
        Debug.Log("==== switch���̗� ====");

        string rank = "B";

        ///switch��
        ///Switch���́Aif�Ƃ͈Ⴂ�A��r����ϐ��ɑ΂��ĊY��������̂𕡐��p�ӂ����򂷂���@
        ///���L�̏ꍇ�A�����N��A��B��C������ȊO����case�ŕ��򂵂��̌��ʂ����s����B
        ///break;�͏������I�����Ӗ����A������Switch���̎��̃v���O���������s�����B
        switch (rank)
        {
            case "A":
                Debug.Log("�ō������N�I");
                break;
            case "B":
                Debug.Log("���������N�I");
                break;
            case "C":
                Debug.Log("���ʂ̃����N");
                break;
            default:
                Debug.Log("�����N�s��");
                break;
        }

        // Switch���́A���������ł͂Ȃ�int�^��float�^�����p�ł���
        int day = 2;
        switch (day)
        {
            case 1:
                Debug.Log("���j��");
                break;
            case 2:
                Debug.Log("�Ηj��");
                break;
            default:
                Debug.Log("���̑��̗j��");
                break;
        }

        ///����case���܂Ƃ߂鎖���ł���B
        ///���̏ꍇKey��13�A��������32�̏ꍇ�A�������������s�����
        ///�Ⴆ��Key�𕐊��ID�ƍl����ΈႤ�����ł������������s���̂Ɠ��l�ɂȂ�
        int key = 13;
        switch (key)
        {
            case 13:
            case 32:
                Debug.Log("Enter�L�[���X�y�[�X�L�[��������܂���");
                break;
            default:
                Debug.Log("���̃L�[�ł�");
                break;
        }
    }

    // ========================
    // for���̗�
    // ========================
    void ShowForExamples()
    {
        Debug.Log("==== for���̗� ====");

        // �p�^�[��1�F0����4�܂ł̃��[�v
        ///�J��Ԃ����߂̒�Ԃł���for����
        ///����̏����ŌJ��Ԃ������ŁA�Ⴆ�΁A�G��x��o�������铙�̎����o����
        ///���L���ƁA5��{ }���̏������J��Ԃ����ɂȂ�B
        ///�����
        ///[int i=0]�����l�ݒ�ŁAi�Ƃ����ϐ���0����
        ///[i<5]��r�`�F�b�N�Ai��5�ȉ��̏ꍇ�J��Ԃ����s���鎖�ɂȂ�A�������Ă��Ȃ����for���I��������
        ///[i++]�J��Ԃ�1������i�̕ϐ���1�����Z���鎖�ɂȂ�
        ///
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("i = " + i);
        }

        ///���̏ꍇ�́A1�����Ƃ�2�����Z�����B
        ///���ʂƂ���5��J��Ԃ����A0�A2�A4�A6�A8�ƂȂ�̂ŋ������o�����ɂȂ�܂��B
        for (int i = 0; i <= 10; i += 2)
        {
            Debug.Log("�����F " + i);
        }

        ///�J��Ԃ��͐��������ł͂Ȃ��t�����\�B
        ///���Z�ł͂Ȃ����Z�ɂ���΋t���ɂȂ�܂��A��!
        ///��r�`�F�b�N���t�ɂȂ鎖��Y�ꂸ��!!
        ///�Y���Ɓy�������[�v�n���z�Ƃ����ň��̃o�O���������܂�!!
        for (int i = 5; i > 0; i--)
        {
            Debug.Log("�J�E���g�_�E���F" + i);
        }
    }

    // ========================
    // while���̗�
    // ========================
    void ShowWhileExamples()
    {
        Debug.Log("==== while���̗� ====");

        int count = 0;

        ///While����for���߂Ƃ͈Ⴂ�y��������������Ă�����薳���ɌJ��Ԃ��z���߂ł�
        ///�l�C�e�B�u�ł̃Q�[���J���ł́A����While���Ńv���O���������[�v�����鎖�ŃQ�[�����̂��I���������Ȃ�����
        ///�I���Ȃ��悤�ɂ��Ȃ���΂Ȃ�܂���A��!
        ///Unity�́y��ȁA�߂ǂ��������A�Ȃ�ł��ɂ�Ȃ��?!�z�Ƃ������炢�A�Q�[�����[�v���������Ă����[�v���Ă���܂��A�֗���
        ///While�����̂́A�Ⴆ�Ό����������z�u��A�C�e���͔z�u���̓���̏��������������܂Ŕz�u��������ȂǂɌ����Ă��܂����A
        ///���͂ƂĂ��댯�Ȗ��߂Ły��������������Ȃ��Ȃ邱�Ƃ�������Ήi���Ƀ��[�v��������z�̂Ŗ������[�v�n�����������鎖������܂��B
        ///�v����!
        while (count < 3)
        {
            Debug.Log("count = " + count);
            count++;
        }

        //While���͕ʂ�int�^�����̏����ł͖�����΂Ȃ�Ȃ��킯�ł͂Ȃ��Abool���̐��U�ł����f���鎖���ł��܂��B
        int value = 10;
        while (value < 5)
        {
            Debug.Log("�\������Ȃ��͂�");
        }

        ///While���̖������[�v�ł��Abreak�ɂ͂��Ȃ��܂���B
        ///break��������΋����I��While���[�v�͒��f�ł��܂��B
        int total = 0;
        while (true)
        {
            total++;
            if (total == 3)
            {
                Debug.Log("3�ŏI��");
                break;
            }
        }
    }

    // ========================
    // foreach���̗�
    // ========================
    void ShowForeachExamples()
    {
        Debug.Log("==== foreach���̗� ====");

        string[] names = { "�o������", "�o���y", "�o���i��" };

        ///�J��Ԃ��ōł����S�Ȃ������ߏ�����Foreach��
        ///for���̂悤�ɓr�������A���l���΂��Ă�A�t�����͏o���Ȃ�����ɁA�������[�v�����i�[���ꂽ���X�g��z��̗v�f�����K���J��Ԃ��ď����ł��܂��B
        ///����ŁA�Q�[�����ɏo�������G���X�g�̑��������G���[�Ȃ��y�X�����ł��܂��B
        foreach (string name in names)
        {
            Debug.Log("���O�F" + name);
        }

        ///Foreach���̓����̈�́u������v���u1�������v�����o���܂��B
        ///�悭�Q�[���ŁA���b�Z�[�W���ꕶ�����\������鉉�o�����邯�ǁA����ŉ\�Ȃ�ł���?
        string word = "Unity";
        foreach (char c in word)
        {
            Debug.Log("�����F" + c);
        }

        ///�Ō�̓��X�g�ɂ�郋�[�v���
        ///���X�g�Ɋi�[���ꂽ�v�f����S�Đ􂢏o���܂�
        var weapons = new System.Collections.Generic.List<string>() { "��", "�|", "��" };
        foreach (string weapon in weapons)
        {
            Debug.Log("����F" + weapon);
        }
    }
}
