using StudyIt.Data;
using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Service
{
    public interface IGroupService
    {
        List<Group> GetGroupsByOwnerId(int ownerId);
        List<Group> GetAllGroups();
        Group GetGroup(int groupId);
        void CreateGroup(Group group);
        void EditGroup(Group group);
        void DeleteGroup(int id);
        string GetGroupName(int groupId);
        List<UserProfile> GetMembersForGroup(int groupId);
        void DeleteMember(int groupId, int memberId);
        List<GroupQuery> GetGroupQueries(int groupId);
        void AddMember(int groupId, int memberId);
        List<Group> GetGroupsByTrainerId(int trainerId);
        List<UserProfile> GetTrainersForGroup(int groupId);
        void DeleteTrainer(int groupId, int trainerId);
        List<TrainerQuery> GetTrainerQueries(int groupId);
        void AddTrainer(int groupId, int trainerId);
        List<Group> GetPublicGroups();
        List<Group> GetGroupsMemberOf(int userId);
        List<Group> GetGroupsNotMemberOf(int userId);
    }
    public class GroupService : IGroupService
    {
        private IGroupRepository groupRepo;
        private IUserRepository userRepo;

        public GroupService()
        {
            var context = new StudyItContext();
            this.groupRepo = new GroupRepository(context);
            this.userRepo = new UserRepository(context);
        }

        public GroupService(IGroupRepository groupRepo, IUserRepository userRepo)
        {
            this.groupRepo = groupRepo;
            this.userRepo = userRepo;
        }

        /// <summary>
        /// Gets all of the groups
        /// </summary>
        /// <returns></returns>
        public List<Group> GetAllGroups()
        {
            return groupRepo.GetAll().Include(x => x.Owner).ToList();
        }

        /// <summary>
        /// Gets given group
        /// </summary>
        /// <param name="groupId">The id of a group</param>
        /// <returns></returns>
        public Group GetGroup(int groupId)
        {
            return groupRepo.Get(groupId);
        }

        /// <summary>
        /// Creates group
        /// </summary>
        /// <param name="group">The group to be created</param>
        public void CreateGroup(Group group)
        {
            groupRepo.Add(group);
            groupRepo.Save();
        }

        /// <summary>
        /// Edits group
        /// </summary>
        /// <param name="group">The group to be edited</param>
        public void EditGroup(Group group)
        {
            groupRepo.Update(group);
            groupRepo.Save();
        }

        /// <summary>
        /// Deletes group
        /// </summary>
        /// <param name="id">The id of a group</param>
        public void DeleteGroup(int id)
        {
            groupRepo.Delete(id);
            groupRepo.Save();
        }

        /// <summary>
        /// Gets all groups by given id of its owner
        /// </summary>
        /// <param name="ownerId">The id of owner</param>
        /// <returns></returns>
        public List<Group> GetGroupsByOwnerId(int ownerId)
        {
            return groupRepo.GetAll().Include(x => x.Owner).Where(x => x.Owner.UserId == ownerId).ToList();
        }

        /// <summary>
        /// Gets the name of given group
        /// </summary>
        /// <param name="groupId">The id of a group</param>
        /// <returns></returns>
        public string GetGroupName(int groupId)
        {
            return groupRepo.Get(groupId).Name;
        }

        /// <summary>
        /// Gets all members of given group
        /// </summary>
        /// <param name="groupId">The id of a group</param>
        /// <returns></returns>
        public List<UserProfile> GetMembersForGroup(int groupId)
        {
            return groupRepo.Get(groupId).Members.ToList();
        }

        /// <summary>
        /// Deletes member of given group
        /// </summary>
        /// <param name="groupId">The id of a group</param>
        /// <param name="memberId">The id of member of the group</param>
        public void DeleteMember(int groupId, int memberId)
        {
            groupRepo.Get(groupId).Members.Remove(groupRepo.Get(groupId).Members.First(x => x.UserId == memberId));
            groupRepo.Save();
        }

        /// <summary>
        /// Gets queries for given group
        /// </summary>
        /// <param name="groupId">The id of a group</param>
        /// <returns></returns>
        public List<GroupQuery> GetGroupQueries(int groupId)
        {
            return groupRepo.Get(groupId).Queries.ToList();
        }

        /// <summary>
        /// Adds member to given group
        /// </summary>
        /// <param name="groupId">The id of a group</param>
        /// <param name="memberId">The id of the member to be added</param>
        public void AddMember(int groupId, int memberId)
        {
            var user = userRepo.Get(memberId);
            groupRepo.Get(groupId).Members.Add(user);
            groupRepo.Save();
        }

        /// <summary>
        /// Gets all groups by id of its trainer
        /// </summary>
        /// <param name="trainerId">The id of a trainer</param>
        /// <returns></returns>
        public List<Group> GetGroupsByTrainerId(int trainerId)
        {
            List<Group> result = userRepo.Get(trainerId).TrainerOf.ToList();
            foreach (var group in this.GetGroupsByOwnerId(trainerId))
            {
                result.Add(group);
            }
            return result;
        }

        /// <summary>
        /// Gets trainers of given group
        /// </summary>
        /// <param name="groupId">The id of a group</param>
        /// <returns></returns>
        public List<UserProfile> GetTrainersForGroup(int groupId)
        {
            return groupRepo.Get(groupId).Trainers.ToList();
        }

        /// <summary>
        /// Deletes trainer from given group
        /// </summary>
        /// <param name="groupId">The id of a group</param>
        /// <param name="trainerId">The id of the trainer to be deleted</param>
        public void DeleteTrainer(int groupId, int trainerId)
        {
            groupRepo.Get(groupId).Trainers.Remove(groupRepo.Get(groupId).Trainers.First(x => x.UserId == trainerId));
            groupRepo.Save();
        }

        /// <summary>
        /// Get queries for trainer of given group
        /// </summary>
        /// <param name="groupId">The id of a group</param>
        /// <returns></returns>
        public List<TrainerQuery> GetTrainerQueries(int groupId)
        {
            return groupRepo.Get(groupId).TrainerQueries.ToList();
        }

        /// <summary>
        /// Adds trainer to given group
        /// </summary>
        /// <param name="groupId">The id of a group</param>
        /// <param name="trainerId">The id of the trainer to be added</param>
        public void AddTrainer(int groupId, int trainerId)
        {
            var user = userRepo.Get(trainerId);
            groupRepo.Get(groupId).Trainers.Add(user);
            groupRepo.Save();
        }

        /// <summary>
        /// Gets all groups which are public
        /// </summary>
        /// <returns></returns>
        public List<Group> GetPublicGroups()
        {
            return groupRepo.GetAll().Where(x => x.Type == GroupType.Public).ToList();
        }

        /// <summary>
        /// Gets all groups given user is member of
        /// </summary>
        /// <param name="userId">The id of a user</param>
        /// <returns></returns>
        public List<Group> GetGroupsMemberOf(int userId)
        {
            var groups = userRepo.Get(userId).MemberOf.ToList();
            foreach (var group in userRepo.Get(userId).Groups.ToList())
            {
                if (group.Type != GroupType.Public)
                {
                    groups.Add(group);
                }
            }
            return groups;
        }

        /// <summary>
        /// Gets all groups given user is not member of
        /// </summary>
        /// <param name="userId">The id of a user</param>
        /// <returns></returns>
        public List<Group> GetGroupsNotMemberOf(int userId)
        {
            var result = new List<Group>();
            var groups = groupRepo.GetAll().ToList();
            foreach (var group in groups)
            {
                if (group.Type == GroupType.Public || group.Owner.UserId == userId)
                {
                    continue;
                }
                bool flag = true;
                foreach (var member in group.Members)
                {
                    if (member.UserId == userId)
                    {
                        flag = false;
                    }
                }
                if (flag == true)
                {
                    result.Add(group);
                }
            }
            return result;
        }
    }
}
