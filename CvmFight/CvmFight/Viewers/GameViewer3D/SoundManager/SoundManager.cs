using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Audio;

namespace CvmFight
{
    class SoundManager
    {
        #region Constants
        public const int Block = 0;

        public const int FastAttempt = 1;
        
        public const int FastHit = 2;

        public const int Jump = 3;

        public const int Ko = 4;

        public const int Perfect = 5;

        public const int StrongKickAttempt = 6;

        public const int StrongKickHit = 7;

        public const int StrongPunchAttempt = 8;

        public const int StrongPunchHit = 9;

        public const int YouLose = 10;

        public const int YouWin = 11;

        #endregion

        #region Fields
        private CachedSound[] internalList;
        #endregion

        #region Constructor
        public SoundManager()
        {
            internalList = new CachedSound[12];
            internalList[Block] = new CachedSound("Assets/Sounds/Block.ogg");
            internalList[FastAttempt] = new CachedSound("Assets/Sounds/FastAttempt.ogg");
            internalList[FastHit] = new CachedSound("Assets/Sounds/FastHit.ogg");
            internalList[Jump] = new CachedSound("Assets/Sounds/Jump.ogg");
            internalList[Ko] = new CachedSound("Assets/Sounds/Ko.ogg");
            internalList[Perfect] = new CachedSound("Assets/Sounds/Perfect.ogg");
            internalList[StrongKickAttempt] = new CachedSound("Assets/Sounds/StrongKickAttempt.ogg");
            internalList[StrongKickHit] = new CachedSound("Assets/Sounds/StrongKickHit.ogg");
            internalList[StrongPunchAttempt] = new CachedSound("Assets/Sounds/StrongPunchAttempt.ogg");
            internalList[StrongPunchHit] = new CachedSound("Assets/Sounds/StrongPunchHit.ogg");
            internalList[YouLose] = new CachedSound("Assets/Sounds/YouLose.ogg");
            internalList[YouWin] = new CachedSound("Assets/Sounds/YouWin.ogg");
        }
        #endregion

        #region Public Methods
        public void Play(int soundIndex)
        {
            internalList[soundIndex].GetSound().Play();
        }

        public void Update(AbstractSprite sprite, AbstractSprite currentPlayer)
        {
            if (!sprite.IsAlive)
            {
                if (sprite == currentPlayer)
                {
                    Play(YouLose);
                }
                else if (sprite.LatestPredator == currentPlayer)
                {
                    if (sprite.Health >= sprite.DefaultHealth)
                    {
                        Play(Perfect);
                    }
                    else
                    {
                        Play(YouWin);
                    }
                }
                else
                {
                    Play(Ko);
                }
            }
            if (sprite.IsJustReceivedStrongPunch)
            {
                Play(StrongPunchHit);
            }
            else if (sprite.IsJustReceivedStrongKick)
            {
                Play(StrongKickHit);
            }
            else if (sprite.IsJustReceivedFastAttack)
            {
                Play(FastHit);
            }
            else if (sprite.CurrentJumpAcceleration == sprite.MaxJumpAcceleration)
            {
                //warning, jump is forced when getting hit so we must evaluate getting hit before jump
                Play(Jump);
            }
            else if (sprite.IsBlock && sprite.BlockSuccessCycle.IsFired && sprite.BlockSuccessCycle.IsAtBegining && sprite.BlockSuccessCycle.IsForward)
            {
                Play(Block);
            }
            else if (sprite.StrongAttackCycle.IsAtBegining && sprite.StrongAttackCycle.IsFired && sprite.StrongAttackCycle.IsForward)
            {
                if (sprite.IsCrouch || sprite.PositionZ > 0)
                    Play(StrongKickAttempt);
                else
                    Play(StrongPunchAttempt);
            }
            else if (sprite.FastAttackCycle.IsAtBegining && sprite.FastAttackCycle.IsFired && sprite.FastAttackCycle.IsForward)
            {
                if (sprite.IsCrouch || sprite.PositionZ > 0)
                    Play(FastAttempt);
                else
                    Play(FastAttempt);
            }
        }
        #endregion
    }
}
